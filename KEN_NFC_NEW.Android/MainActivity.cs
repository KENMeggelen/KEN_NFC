﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Nfc;
using Plugin.NFC;
using Android.Content;

namespace KEN_NFC_NEW.Droid {

    [Activity(Label = "KEN_NFC_NEW", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    [IntentFilter(new[] {NfcAdapter.ActionNdefDiscovered}, Categories = new[] {Intent.CategoryDefault}, DataMimeType = MainPage.MIME_TYPE)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            CrossNFC.Init(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume() {
            base.OnResume();
            CrossNFC.OnResume();
        }

        protected override void OnNewIntent(Intent intent) {
            base.OnNewIntent(intent);
            CrossNFC.OnNewIntent(intent);
        }
    }
}