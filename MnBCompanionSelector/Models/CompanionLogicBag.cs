using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MnBCompanionSelector.Models
{
	public class CompanionLogicBag
	{
		//dbContext db=new dbContext();
		public IEnumerable<Companion> AvailableList { get; set; }
		public IEnumerable<Companion> ChosenList { get; set; }
		public IEnumerable<string> Mods { get; set; }
		public CompanionLogicBag(){
			Mods = new List<string>();
			AvailableList = new List<Companion>();
			ChosenList = new List<Companion>();
		}
	}
}