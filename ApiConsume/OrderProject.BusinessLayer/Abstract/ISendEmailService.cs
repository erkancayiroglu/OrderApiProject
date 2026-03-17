using OrderProject.DtoLayer.Mail;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.BusinessLayer.Abstract
{
    public interface ISendEmailService:IGenericService<SendEmail>
    {
        public void TAddSendEmail(AddSendEmailDto sendEmail);

        public void TPasswordSendEmail(AddSendEmailDto sendEmail);
    }
}
