using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudience	= "https://localhost";
		public const string ValidIssuer		= "http://localhost";
		public const string Key				= "KiralaDur?Car+Book..Project1181@@UdemyProject6604..?=newtokenKey]/carBook";
		public const int Expire				= 3;
	}
}
