using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BookCatalogue.DAL;
using System.Data;

namespace BookCatalogueDemo
{
    [GlobalErrorHandlerBehaviour(typeof(GlobalErrorHandler))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class BooksCatalogueService : IBooksCatalogueService
    {
        DataSet IBooksCatalogueService.SearchCatalogue()
        {
            DataSet dataSet = BookCatalogueLogicsDAL.SearchCatalogueDAL();
            try
            {
                return (!(dataSet.Tables[0].Rows.Count == 0)) ? dataSet : null;
            }
            catch(Exception ex)
            {
                Log.Error(ex);

                FaultExceptionHandler faultExceptionHandler = new FaultExceptionHandler();
                //faultExceptionHandler.Error = ex.Message;
                faultExceptionHandler.Details = "A general service error occured. Please, try agian.";

                throw new FaultException<FaultExceptionHandler>(faultExceptionHandler);
            }
        }

        DataSet IBooksCatalogueService.GetAllBooks(int ID, string SearchValue)
        {
            DataSet dataSet = BookCatalogueLogicsDAL.GetAllBooks(ID, SearchValue);
            if (dataSet != null)
            {
                if (!(dataSet.Tables[0].Rows.Count == 0))
                {
                    return dataSet;
                }
                else
                    return null;
            }
            else
                return null;
        }

        int IBooksCatalogueService.SaveBook(Books books)
        {
            return books != null ? BookCatalogueLogicsDAL.UpdateBook(books.BookId,books.BookName, books.Author, books.Price)
                : -1;
        }

        int IBooksCatalogueService.InsertNewBook(Books books)
        {
            return books != null ? BookCatalogueLogicsDAL.InsertNewBook(books.BookName, books.Author, books.Price)
                : -1;
        }

        int IBooksCatalogueService.DeleteBook(int ID)
        {
            return BookCatalogueLogicsDAL.DeleteBook(ID);
        }
    }
}
