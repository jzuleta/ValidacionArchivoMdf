using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Components
{
    public class ValidateMdf
    {
        private MdfFile db;
        private int countErrors = 0;
        public bool isValid { get; set; }
        public List<string> listErrors { get; set; }
        /*     Descripción
               AF          Foreign Key no validadas     
               C           Check
               CT          Cantidad de tablas
               F           Foreign key
               FN          Función escala
               P           Procedimiento almacenado
               PK          Primary key
               TF          Función de tabla
               TR          Trigger
        */
        private readonly string[] _objDb = new[] { "AF", "C", "CT", "F", "FN", "P", "PK", "TF", "TR" };
        private object[] _compareConfig = new[] { 
            new[] { 0, 0, 13, 11, 0, 0, 11, 0, 0 },    //NODO
            new[] { 0, 0, 5, 1, 0, 0, 3, 0, 0 },       //CONEXION
            new[] { 0, 0, 55, 70, 0, 44, 53, 0, 0 }    //FULL
        };
        #region Query
        private string _query = @"DECLARE
                                        @objectsList TABLE(objectType char(2),
				                                        objectName varchar(20));
                                    INSERT INTO @objectsList(objectType,
					                                    objectName)
                                    VALUES('PK','PRIMARY KEY'),
	                                        ('F','FOREIGN KEY'),
	                                        ('FN','SCALAR FUNCTION'),
	                                        ('P','STORED PROCEDURE'),
	                                        ('TR','TRIGGER'),
	                                        ('C','CHECK'),
	                                        ('TF','TABLE FUNCTION');
                                    SELECT objectType,
	                                        objectName,
	                                        (
	                                        SELECT COUNT(*)
		                                    FROM sysobjects obj
		                                    WHERE obj.xtype = x.objectType
		                                        AND obj.status >= 0
		                                        AND obj.name NOT LIKE 'sp_%')total
                                        FROM @objectsList x
                                    UNION
                                    SELECT 'CT',
	                                        'COUNT TABLES',
	                                        COUNT(DISTINCT so.name)
                                        FROM sys.objects so
                                        WHERE so.type = 'u'
                                        AND so.name != 'sysdiagrams'
                                    UNION
                                    SELECT 'AF',
	                                        'ALTER FK',
	                                        COUNT(*)
                                        FROM sys.foreign_keys
                                        WHERE is_not_trusted = 1
	                                    OR is_disabled = 1;";
        #endregion

        public ValidateMdf(MdfFile db)
        {
            this.db = db;
            createConfiguration();
            executeValidation();
        }

        public ValidateMdf()
        {
            listErrors = new List<string>();
        }

        private void executeValidation()
        {
            listErrors = new List<string>();
            var arrayValidation = (int[])_compareConfig[db.Part - 1];

            for (var i = 0; i < _objDb.Length; i++)
            {
                if (db.dbConfig[_objDb[i]].ToString() != arrayValidation[i].ToString())
                {
                    listErrors.Add(_objDb[i]);
                    countErrors++;
                }
            }

            isValid = (countErrors == 0);
        }

        private void createConfiguration()
        {
            var cnn = new SqlConnection
            {
                ConnectionString =
                    string.Format(SqlServerInstance.StringConnection, db.code)
            };

            using (
                var cmdSql = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = _query,
                    Connection = cnn
                })
            {
                if (cnn.State != ConnectionState.Open)
                    cnn.Open();

                var data = cmdSql.ExecuteReader(CommandBehavior.CloseConnection);
                while (data.Read())
                {
                    db.dbConfig.Add(data.GetString(0).Trim(), data.GetInt32(2).ToString());
                }
            }
        }
    }
}
