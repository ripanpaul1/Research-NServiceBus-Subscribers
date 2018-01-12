using System.Threading.Tasks;
using System.Net;
using NServiceBus;
using Lateetud.NServiceBus.Common.Models.Smart;
using Lateetud.NServiceBus.DAL.Smart;
using Lateetud.NServiceBus.DAL.ef;

public class OcrHandler :
    IHandleMessages<OCR>
{
    public Task Handle(OCR message, IMessageHandlerContext context)
    {
        string OCR_Result = "Done";

        // invoke OCR layer to get processed data
        //OCRInvoker_LocalIIS.WebService1 OCR_Obj = new OCRInvoker_LocalIIS.WebService1();
        //OCR_Obj.Credentials = new NetworkCredential("Ap1", "Password1", "BPMSERVER");
        //string OCR_Output = OCR_Obj.OCRInvoker_BPMSERVER();
        //OCR_Output = OCR_Output.Trim();
        //OCR_Output = OCR_Output.Replace("3_ac", "3_Ac");

        //OCR_Output = "[[[_List of Process References:::" + message.Message + "]]]" + OCR_Output;
        //if (OCR_Output.Contains("[[[3_"))
        //    OCR_Result = "Recognized";
        //else OCR_Result = "Not Recognized";

        // invoke aura service & send data to service
        //SubmissionProcess_EM.WS_OCR_File_Data_Sub sub_Proc_obj = new SubmissionProcess_EM.WS_OCR_File_Data_Sub();
        //sub_Proc_obj.Credentials = new NetworkCredential("Ap1", "Password1", "BPMSERVER");
        //int Ap_returnCode = sub_Proc_obj._WS_OCR_File_Data_Sub(OCR_Output);

        // db operation here
        new SmartOcrManager().Update(new SmartOcr { RequestId = message.RequestID, MessageId = context.MessageId, Status = OCR_Result });


        return Task.CompletedTask;


        //return Task.FromCanceled(System.Threading.CancellationToken.None);
    }


    

}


