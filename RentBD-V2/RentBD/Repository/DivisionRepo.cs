using RentBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentBD.Repository
{
    public class DivisionRepo
    {
        private SqlConnection sqlConn;
        private SqlCommand cmd;
        private readonly DBConnector objDBConnector;

        ///
        /// Constructor
        ///

        public DivisionRepo()
        {
            objDBConnector = new DBConnector();
            sqlConn = objDBConnector.GetConn();
            cmd = objDBConnector.GetCommand();
        }

        public string InsertDivision(Division division)
        {
            string msg = String.Empty;

            int noOfRowEffected = 0;

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Division ( Name )"
                + " VALUES('" + division.Name + "')";

                noOfRowEffected = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            if (noOfRowEffected > 0)
                return "Division information saved successfully!";
            else
                return msg;
        }


        public List<Division> GetDivisionInfoAll()
        {
            DataTable tblDivisionInfo = new DataTable();
            SqlDataReader rdr = null;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT Id, Name FROM Division";

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                rdr = cmd.ExecuteReader();
                tblDivisionInfo.Load(rdr);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            //return tblDivisionInfo;


            //Convert Data Table to List

            List<Division> divisionList = new List<Division>();
            divisionList = Utility.ConvertDataTable<Division>(tblDivisionInfo);
            //ConvertDataTable<Student>(dt);

            return divisionList;
        }

    }
}