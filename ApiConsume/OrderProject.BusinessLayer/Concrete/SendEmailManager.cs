using OrderProject.BusinessLayer.Abstract;
using OrderProject.DataAccessLayer.Abstract;
using OrderProject.DtoLayer.Mail;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.BusinessLayer.Concrete
{
    public class SendEmailManager : ISendEmailService
    {
        private readonly ISendEmailDal _sendEmailDal;
        public SendEmailManager(ISendEmailDal sendEmailDal)
        {
            _sendEmailDal = sendEmailDal;
        }

        public void TDelete(SendEmail t)
        {
           _sendEmailDal.Delete(t);
        }

        public SendEmail TGetById(int id)
        {
           return _sendEmailDal.GetById(id);
        }

        public List<SendEmail> TGetList()
        {
            return _sendEmailDal.GetList();
        }

        public void TInsert(SendEmail t)
        {
            _sendEmailDal.Insert(t);
        }

        public void TAddSendEmail(AddSendEmailDto sendEmail)
        {
             _sendEmailDal.AddSendEmail(sendEmail);
        }

        public void TUpdate(SendEmail t)
        {
           _sendEmailDal.Update(t);
        }
    
    }
}
