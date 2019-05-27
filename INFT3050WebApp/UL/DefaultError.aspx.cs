using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL
{
    public partial class DefaultError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = Request.QueryString["error"];
            string errorTrace = Request.QueryString["stacktrace"];
            string innerException = Request.QueryString["innerex"];
            string defaultString = "An error has occured with the web application. Please contact customer support for details on this issue.";
            string unhandledErrorMsg = "The error was unhandled by application code.";

            // Show default error message to user
            lblErrorText.Text = defaultString;

            // Determine where error was handled.
            string errorHandler = Request.QueryString["handler"];
            if (errorHandler == null)
            {
                errorHandler = "Error Page";
            }

            // Get the last error from the server.
            Exception exception = Server.GetLastError();

            if (exception == null)
            {
                exception = new Exception(unhandledErrorMsg);
            }

            lblErrorHandler.Text = errorHandler;

            lblErrorDetails.Text = exception.Message;

            // Show details only if developer is running the application
            if (Request.IsLocal)
            {
                if (exception.InnerException != null)
                {
                    lblInnerMessage.Text = exception.GetType().ToString() + "<br/>" + exception.InnerException.Message;
                    lblInnerTrace.Text = exception.InnerException.StackTrace;
                }
                else
                {
                    lblInnerMessage.Text = exception.GetType().ToString();
                    if (exception.StackTrace != null)
                    {
                        lblInnerTrace.Text = exception.StackTrace.ToString().TrimStart();
                    }
                }
                panErrorDetails.Visible = true;
                //lblErrorDetails.Text = errorMessage;
                //lblInnerTrace.Text = errorTrace;
                //lblInnerMessage.Text = innerException;
            }
        }
    }
}