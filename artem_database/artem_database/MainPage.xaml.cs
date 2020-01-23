using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace artem_database
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }




        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Friend selectedFriend = (Friend)e.SelectedItem;
            FriendPage friendPage = new FriendPage();
            friendPage.BindingContext = selectedFriend;
            if (selectedFriend.DLeft<3 && selectedFriend.Close==false)

            {

                var action = await DisplayActionSheet("Поздравить с днём рождения?", "Отменить", null, "SMS", "Телефон", "E-mail");
                switch (action)
                {
                    case "SMS":
                        var smsMessenger = CrossMessaging.Current.SmsMessenger;
                        if (smsMessenger.CanSendSms)
                            smsMessenger.SendSms(selectedFriend.Phone, "С днём рождения, " + selectedFriend.Name + "!\n" + "Через " + selectedFriend.DLeft + " дней, тебе будет уже " + selectedFriend.Age + ".\nЖелаю счастья и успехов!");
                        selectedFriend.Close = true;
                        break;
                    case "Телефон":
                        var phoneDilaer = CrossMessaging.Current.PhoneDialer;
                        if (phoneDilaer.CanMakePhoneCall)
                            phoneDilaer.MakePhoneCall(selectedFriend.Phone);
                        selectedFriend.Close = true;
                        break;
                    case "E-mail":
                        var emailMessenger = CrossMessaging.Current.EmailMessenger;
                        if (emailMessenger.CanSendEmail)
                            emailMessenger.SendEmail(selectedFriend.Email, "День рождения", "С днём рождения!" + selectedFriend.Name + "!\n" +"Через " +selectedFriend.DLeft +" дней, тебе будет уже " + selectedFriend.Age+".\nЖелаю счастья и успехов!" );
                        selectedFriend.Close = true;
                        break;
                    case "Отменить":
                        selectedFriend.Close = true;
                        break;

                }
                if (!String.IsNullOrEmpty(selectedFriend.Name))
                {
                    App.Database.SaveItem(selectedFriend);
                }



            }
            
            await Navigation.PushAsync(friendPage);
            
        }
        // обработка нажатия кнопки добавления
        private async void CreateFriend(object sender, EventArgs e)
        {
            Friend friend = new Friend();
            FriendPage friendPage = new FriendPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }
    }
}
