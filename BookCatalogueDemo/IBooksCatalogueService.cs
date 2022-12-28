using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace BookCatalogueDemo
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IBooksCatalogueService
    {
        [FaultContract(typeof(FaultExceptionHandler))]
        [OperationContract(IsOneWay = false)]
        DataSet SearchCatalogue();

        [OperationContract(ProtectionLevel = System.Net.Security.ProtectionLevel.None)]
        DataSet GetAllBooks(int ID, string SearchValue);

        [OperationContract]
        int InsertNewBook(Books books);

        [OperationContract]
        int SaveBook(Books books);

        [OperationContract]
        int DeleteBook(int ID);
    }
}
