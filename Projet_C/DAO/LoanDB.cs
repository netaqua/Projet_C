using Projet_C.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C.DAO
{
    internal class LoanDB
    {
        private String connectionString;

        public LoanDB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LoanDB"].ConnectionString;
        }

        public bool Create(Loan l)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Loan(StartDate, EndDate, OnGoing, idCopy, idHirer, idTenant) VALUES({l.StartDate}, '{l.EndDate}', '{l.OnGoing}', {l.Copy.IdCopy},{l.Hirer.IdPlayer},{l.Tenant.IdPlayer})", connection);
                cmd.Parameters.AddWithValue("startDate", l);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public Loan Read(String loanType)
        {
            Loan l = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Loan WHERE idLoan='@idLoan'", connection);

                cmd.Parameters.AddWithValue("name", loanType);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        l = new Loan();
                        l.IdLoan = reader.GetInt32("idLoan");
                        l.StartDate = reader.GetDateTime("startDate");
                        l.EndDate = reader.GetDateTime("endDate");
                        l.OnGoing = reader.GetBoolean("onGoing");
                        l.Copy.IdCopy = reader.GetInt32("copy");
                        l.Hirer.IdPlayer = reader.GetInt32("hirer");
                        l.Tenant.IdPlayer = reader.GetInt32("tenant");
                    }
                }
            }
            return l;
        }
        public bool Update(Loan l)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.Loan SET StartDate = {l.StartDate}, EndDate = {l.EndDate}, OnGoing = {l.OnGoing}, idCopy = {l.Copy.IdCopy}, idHirer = {l.Hirer.IdPlayer}, idTenant = {l.Tenant.IdPlayer}", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public bool Delete(Loan l)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Loan WHERE idLoan = {l.IdLoan}", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }


        public List<Loan> ReadAll()
        {
            List<Loan> loan = new List<Loan>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Loan", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Loan l = new Loan();
                        l.IdLoan = reader.GetInt32("idLoan");
                        l.StartDate = reader.GetDateTime("startDate");
                        l.EndDate = reader.GetDateTime("endDate");
                        l.OnGoing = reader.GetBoolean("onGoing");
                        l.Copy.IdCopy = reader.GetInt32("copy");
                        l.Hirer.IdPlayer = reader.GetInt32("hirer");
                        l.Tenant.IdPlayer = reader.GetInt32("tenant");
                        loan.Add(l);
                    }
                }
            }
            return loan;
        }


    }
}

