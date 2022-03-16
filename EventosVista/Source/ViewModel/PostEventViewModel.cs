﻿using EventosVista.Source.Access;
using EventosVista.Source.Core.Command;
using EventosVista.Source.Model;
using System;
using System.Windows;

namespace EventosVista.Source.ViewModel
{
    internal class PostEventViewModel
    {
        FireBaseUploader fbu;
        public PostEventViewModel()
        {
            fbu = new FireBaseUploader();

        }
        public async void PostEvent(string title, DateTime start, DateTime finish, string place, string desc, string imageName)
        {
            await fbu.UploadFile(imageName);

            Event evento = new Event()
            {
                Titulo = title,
                Descripcion = desc,
                FechaInicio = start,
                FechaFinal = finish,
                Lugar = place,
                Organizador = Session.GetInstance().User,
                Banner = fbu.latestUpload
            };
            fbu.latestUpload = "";

            SaveCommand saveEvent = new SaveCommand(evento);
            Invoker.getInstance().setCommand(saveEvent);
            Invoker.getInstance().execute();
            if (saveEvent.response)
            {
                MessageBox.Show("Evento agregado!");
            }
        }
    }
}
