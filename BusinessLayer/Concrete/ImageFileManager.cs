using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ImageFileManager : IImageFileService
	{
		EfImageFileDal _ImageFileDal;

		public ImageFileManager(EfImageFileDal ımageFileDal)
		{
			_ImageFileDal = ımageFileDal;
		}

		public List<ImageFile> GetList()
		{
			return _ImageFileDal.List();
		}
	}
}
