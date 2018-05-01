using RentBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentBD.Repository
{
    public class DistrictRepo
    {

        private SqlConnection sqlconn;
        private SqlCommand cmd;
        private readonly DBConnector objDBConnector;



        public DistrictRepo(){
            objDBConnector = new DBConnector();

            sqlconn = objDBConnector.GetConn();
            cmd = objDBConnector.GetCommand();



        }

        public string insertDistrict(District district) {

            String msg = String.Empty;
            int noOfRowEffected = 0;


            try {

                if (sqlconn.State == ConnectionState.Closed) {

                    sqlconn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO district ( Name )"
               + " VALUES('" + district.Name + "')";
                    noOfRowEffected = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }



            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqlconn.Close();
            }

            if (noOfRowEffected > 0)
                return "District information saved successfully!";
            else
                return msg;
        }
        public List<District> GetAllDistrictInfo() {

        

            DataTable tblDistrictinfo = new DataTable();
            SqlDataReader rdr = null;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Id,Name From district";
            try
            {
                if (sqlconn.State == ConnectionState.Closed)
                {
                    sqlconn.Open();

                    rdr = cmd.ExecuteReader();
                    tblDistrictinfo.Load(rdr);


                }
            }

            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqlconn.Close();
            }
            List<District> districtList = new List<District>();
            districtList = Utility.ConvertDataTable<District>(tblDistrictinfo);
            //ConvertDataTable<Student>(dt);

            return districtList;


        }


        public string updateDistrictinfo(District district) {
            string msg = string.Empty;
            int numberRow = 0;

            try {
                if (sqlconn.State == ConnectionState.Closed)
                {
                    sqlconn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update district set Name = '" + district.Name +"'";

                    numberRow = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();





                }

            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqlconn.Close();
            }

            if (numberRow > 0)
                return "Update information updated successfully!";
            else
                return msg;
        }


        public string deleteDistrict(int id) {

            string msg = string.Empty;

            int number = 0;
            try {
                if (sqlconn.State == ConnectionState.Closed) {
                    sqlconn.Open();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "Delete from district " + "where Id = " + id;
                    number = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }

            }
            catch (Exception exp) {

                throw (exp);

            }

            finally
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqlconn.Close();
            }

            if (number > 0)
                return "Delete information updated successfully!";
            else
                return msg;
        }

    }




    }









    

