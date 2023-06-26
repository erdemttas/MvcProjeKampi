﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class MessageManager : IMessageService
	{
		IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public Message GetByID(int id)
		{
			return _messageDal.Get(x => x.MessageID == id);
		}

		public List<Message> GetListSendbox()
		{
			return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
		}

		public List<Message> GetListInbox()
		{
			return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
		}

		public void messageAdd(Message message)
		{
			_messageDal.Insert(message); 
		}

		public void messageRemove(Message message)
		{
			throw new NotImplementedException();
		}

		public void messageUpdate(Message message)
		{
			throw new NotImplementedException();
		}
	}
}