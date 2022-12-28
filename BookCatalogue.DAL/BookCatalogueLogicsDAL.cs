using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BookCatalogue.DAL
{
    public class BookCatalogueDBLogic
    {
        public const string StoredProcedure = "sp_BookCatalogue";

        public const string GetBookById = "a";
        public const string SearchCatalogue = "b";
        public const string GetValuesFromSearchCatalogue = "c";
        public const string GetAllBooks = "d";
        public const string InsertNewBook = "e";
        public const string UpdateBook = "f";
        public const string DeleteBook = "g";
    }
    public class BookCatalogueLogicsDAL
    {
        //Search Catalogue 
        public static DataSet SearchCatalogueDAL()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = LogicBase.GetConnectionString();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = new SqlCommand();

                    sqlDataAdapter.SelectCommand.Connection = sqlConnection;

                    sqlDataAdapter.SelectCommand.CommandText = BookCatalogueDBLogic.StoredProcedure;
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@mode", BookCatalogueDBLogic.SearchCatalogue);

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);

                    return dataSet;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception);
                return null;
            }
        }

        //Get All Books
        public static DataSet GetAllBooks(int ID, string SearchValue)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = LogicBase.GetConnectionString();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = new SqlCommand();

                    sqlDataAdapter.SelectCommand.Connection = sqlConnection;

                    sqlDataAdapter.SelectCommand.CommandText = BookCatalogueDBLogic.StoredProcedure;
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@mode", BookCatalogueDBLogic.GetAllBooks);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@GetValueFromSearchCatalogueID", ID);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@SerachValue", SearchValue);

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);

                    return dataSet;
                }
            }
            catch (Exception exception)
            {
                Log.Error( exception);
                return null;
            }
        }

        //Add New Book
        public static int InsertNewBook(string BookName, string Author, decimal Price)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = LogicBase.GetConnectionString();

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = BookCatalogueDBLogic.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@mode", BookCatalogueDBLogic.InsertNewBook);
                    sqlCommand.Parameters.AddWithValue("@BookName", BookName);
                    sqlCommand.Parameters.AddWithValue("@Author", Author);
                    sqlCommand.Parameters.AddWithValue("@Price", Price);
                    

                    sqlConnection.Open();
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception);
                return 0;
            }
        }

        //Edit Book
        public static int UpdateBook(int BookID, string BookName, string Author, decimal Price)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = LogicBase.GetConnectionString();

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = BookCatalogueDBLogic.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@mode", BookCatalogueDBLogic.UpdateBook);
                    sqlCommand.Parameters.AddWithValue("@BookName", BookName);
                    sqlCommand.Parameters.AddWithValue("@Author", Author);
                    sqlCommand.Parameters.AddWithValue("@Price", Price);
                    sqlCommand.Parameters.AddWithValue("@BookId", BookID);

                    sqlConnection.Open();
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception);
                return 0;
            }
        }

        //Delete Book
        public static int DeleteBook(int BookID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = LogicBase.GetConnectionString();

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = BookCatalogueDBLogic.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@mode", BookCatalogueDBLogic.DeleteBook);
                    sqlCommand.Parameters.AddWithValue("@BookId", BookID);

                    sqlConnection.Open();
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception);
                return 0;
            }
        }
    }
}
