using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameLibrary.Models{

	public class Game{

		private static int nextId = 0;
		public int? Id { get; set; } = nextId++;

		public string Title { get; set; } = "No Title";
		public string Platform { get; set; } = "Not Released";

		public string Genre { get; set; } = "Sanbox";

		public string Esrb { get; set; } = "M";
		public int Year { get; set; } = 2000;

		public string? Image { get; set; }

		public bool onLoan = false;
		public string? LoanedTo { get; set; }

		public DateTime? LoanedDate { get; set; }

		public Game() { }

		public Game(string title, string platform, string genre, string esrb, int year, string? image, string? loanedTo, DateTime? loanedDate){

			this.Title = title;

			this.Platform = platform;

			this.Genre = genre;

			this.Esrb = esrb;

			this.Year = year;

			if(image != null) this.Image = image;

			if(loanedTo != null) this.LoanedTo = loanedTo;

			if(loanedDate != null) this.LoanedDate = loanedDate;

		}

	}

}
