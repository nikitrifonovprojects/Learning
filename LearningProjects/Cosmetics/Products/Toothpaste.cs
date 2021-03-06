﻿using System;
using System.Collections.Generic;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Toothpaste : AbstractProduct, IToothpaste
    {
        private string ingridients;
        private const int MinIngridientLenght = 4;
        private const int MaxIngridientLenght = 12;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients) 
            : base(name, brand, price, gender)
        {
            if (!IsValid(ingredients))
            {
                throw new ArgumentException(string.Format("Each ingredient must be between {0} and {1} symbols long!", Toothpaste.MinIngridientLenght, Toothpaste.MaxIngridientLenght));
            }

            this.Ingredients = IngridientsToString(ingredients);
        }

        public string Ingredients
        {
            get
            {
                return this.ingridients;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value);
                }
                else
                {
                    this.ingridients = value;
                }
            }
        }

        public override string Print()
        {
            return string.Format(base.Print() + Environment.NewLine + "  * Ingredients: {0}", this.ingridients);
        }

        private string IngridientsToString(IList<string> ingridients)
        {
            var result = new StringBuilder();
            
            for (int i = 0; i < ingridients.Count; i++)
            {
                var currentIngidient = ingridients[i];
                if (i != ingridients.Count - 1)
                {
                    result.Append(currentIngidient + "," + " ");
                }
                else
                {
                    result.Append(currentIngidient);
                }
            }

            return result.ToString();
        }

        private bool IsValid(IList<string> ingridients)
        {
            foreach (var ingridient in ingridients)
            {
                if (ingridient.Length < Toothpaste.MinIngridientLenght && ingridient.Length <= Toothpaste.MaxIngridientLenght)
                {
                    return false;
                    
                }
            }

            return true;
        }
    }
}
