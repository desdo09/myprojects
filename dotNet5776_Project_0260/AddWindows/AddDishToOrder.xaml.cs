﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BL;
using System.Collections.ObjectModel;

namespace dotNet5776_Project_0260
{
    /// <summary>
    /// Interaction logic for AddDishToOrder.xaml
    /// </summary>
    public partial class AddDishToOrder : Window
    {
        //Bl Object
        static IBL Bl_Object = BL.FactoryBL.GetBL();
        //Anothers windows will register in Sendish to get the Item
        public event EventHandler<BE.Dish> SendDish = null;
        //just like List<Dish>, but in this case all changed will made in datagrid
        ObservableCollection<BE.Dish> items;
        public AddDishToOrder()
        {
            InitializeComponent();
            try
            {
                items = new ObservableCollection<BE.Dish>(Bl_Object.GetAllDish());
            }
            catch (Exception)
            {

                MessageBox.Show("There are no dishes in database", "Add dish");
                this.Loaded += ((x, y) => this.Close());
            }
            DishData.ItemsSource = items;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse((sender as Button).Tag.ToString());
                if (SendDish != null)
                {
                    SendDish(this, Bl_Object.SearchDishById(id));
                    // new Thread(() => { MessageBox.Show("Added successful"); }).Start();
                }
                else
                    new NullReferenceException("SendDish null");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType() + ": " + ex.Message);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            //Casting sender to Texbox
            TextBox search = sender as TextBox;
            //In case that the Textbox is empty then copy to items all DishList
            if (string.IsNullOrEmpty(search.Text))
            {
                foreach (var item in Bl_Object.GetAllDish())
                {
                    items.Add(item);
                }
                DishData.ItemsSource = items;
                return;
            }
            //cleaner item
            items.Clear();
            //The new list will ask to BL if there are item that contain the text inserted in Textbox. 
            List<BE.Dish> dishes = Bl_Object.SearchInDish(item => item.DishId.ToString().Contains(search.Text)    ||
                                                                  item.DishName.Contains(search.Text)             ||
                                                                  item.DishPrice.ToString().Contains(search.Text) ||
                                                                  item.DishSize.ToString().Contains(search.Text)  ||
                                                                  item.HashgachaDish.ToString().Contains(search.Text));
            if (dishes != null)//if found something
            {
                //add to items(lists) the items founded
                foreach (var item in dishes)
                {
                    items.Add(item);
                }
            }




        }
    }
}
