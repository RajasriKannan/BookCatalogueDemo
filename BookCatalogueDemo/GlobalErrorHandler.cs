using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using BookCatalogue.DAL;

namespace BookCatalogueDemo
{
    class GlobalErrorHandler : IErrorHandler
    {
        bool IErrorHandler.HandleError(Exception ex)
        {
            Log.Error(ex);
            return true;
        }

        void IErrorHandler.ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
                return;

            // Return a general service error message to the client
            FaultException faultException = new FaultException("A general service error occured");
            MessageFault messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, null);
        }
    }
}
