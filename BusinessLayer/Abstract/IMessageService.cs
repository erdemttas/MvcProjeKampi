using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMessageService
	{
		List<Message> GetListInbox();
		List<Message> GetListSendbox();
		void messageAdd(Message message);
		void messageRemove(Message message);
		void messageUpdate(Message message);
		Message GetByID(int id);
	}
}
