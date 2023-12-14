﻿using Domain_Models.Database;
using Domain_Models.Enums;
using Domain_Models.Webshop.Medias;
using Domain_Models.Webshop.Users;
using Microsoft.Data.SqlClient;
using System;
using System.Net;

namespace Domain_Models.Webshop
{
    public class Listing : IDatabaseEntry
    {
        // Properties
        public int ID { get; set; }
        public int Price { get; set; }
        public Media Item { get; set; }
        public Seller Seller { get; set; }
        public CONDITION Condition { get; set; }

        // Methods specific to Listing
        public bool TryUpdateListing() { return true; }
        public bool TryRemoveListing() { return true; }

        // Methods from IDatabaseEntry
        public IDatabaseEntry GetDBEntry(int pKey)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM listing_table WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", pKey);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            ID = int.Parse(result[0]);
            Price = int.Parse(result[1]);
            Item.Id = int.Parse(result[2]);
            Item.Title = result[3];
            Item.Description = result[4];
            Item.Price = int.Parse(result[5]);
            Item.ImagePath = result[6];
            Seller.Name = result[7];
            Seller.Email = result[8];
            Seller.PhoneNumber = int.Parse(result[9]);
            Seller.Address = result[10];
            Condition = (CONDITION) int.Parse(result[11]);
           

            return this; ;
        }

        public void AddDBEntry()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO listing_table (listing_price, media_id, seller_id, condition) OUTPUT Inserted.listing_id VALUES (@listing_price, @media_id, @seller_id, @condition)");
            cmd.Parameters.AddWithValue("@listing_price", Price);
            cmd.Parameters.AddWithValue("@media_id", Item);
            cmd.Parameters.AddWithValue("@seller_id", Seller);
            cmd.Parameters.AddWithValue("@condition", $"{Condition}");

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            ID = int.Parse(result[0]);
        }

        public void RemoveDBEntry()
        {
            if (ID == 0)
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM listing_table WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", ID);

            DatabaseHandler.FetchFromTable(cmd);
        }

        public bool UpdateDBEntry()
        {
            if (ID == 0)
            {
                return false;
            }
            SqlCommand cmd = new SqlCommand("UPDATE listing_table SET listing_price = @listing_price, media_id = @media_id, seller_id = @seller_id, condition = @condition WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@listing_price", Price);
            cmd.Parameters.AddWithValue("@media_id", Item);
            cmd.Parameters.AddWithValue("@seller_id", Seller);
            cmd.Parameters.AddWithValue("@condition", Condition);

            DatabaseHandler.FetchFromTable(cmd);
            return true;
        }
    }
    
}