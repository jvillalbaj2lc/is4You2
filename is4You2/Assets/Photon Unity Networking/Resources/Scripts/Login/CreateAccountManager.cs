using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace Com.Afrodita.isForYou2
{
    public class CreateAccountManager : MonoBehaviour
    {
        public Transform register;
        public Transform login;
        public InputField nombre;
        public InputField email;
        public InputField password;
        public Dropdown paises;
        public Dropdown dia;
        public Dropdown mes;
        public Dropdown year;
        public Button createAccount;
        public List<Text> camposRequeridos;
        private Entidades.Cuenta cuenta = new Entidades.Cuenta();
        private bool camposCompletados = false;

        public void Start() {
            InicializarComponentes();
        }
        public void CrearCuenta()
        {
            cuenta.Nombre = nombre.text;
            cuenta.Email = email.text;
            cuenta.Password = password.text;
            cuenta.Pais = Convert.ToInt32(paises.value);
            cuenta.FechaNacimiento = new DateTime(Convert.ToInt32(year.captionText.text), Convert.ToInt32(mes.captionText.text), Convert.ToInt32(dia.captionText.text));

            Cuenta.InsertarCuenta(cuenta);
        }
        public void OnLogin() {
            register.gameObject.SetActive(false);
            login.gameObject.SetActive(true);
        }
        public void OnRegister() {
            login.gameObject.SetActive(false);
            register.gameObject.SetActive(true);
        }
        public void OnEnter() {
        }

        public void OnCheckRequiredFields(InputField campo) {
            if (!string.IsNullOrEmpty(campo.text))
                campo.transform.Find("ErrorField").gameObject.SetActive(false);
            else
                campo.transform.Find("ErrorField").gameObject.SetActive(true);

            ComprobarCamposRequeridos();
        }
        public void OnCheckRequiredFields(Dropdown lista) {
            if (!string.IsNullOrEmpty(lista.captionText.text))
                lista.transform.Find("ErrorField").gameObject.SetActive(false);
            else
                lista.transform.Find("ErrorField").gameObject.SetActive(true);
            ComprobarCamposRequeridos();
        }
        public void OnCheckRequiredFields(Toggle check) {
            if (check.isOn)
                check.transform.Find("ErrorField").gameObject.SetActive(false);
            else
                check.transform.Find("ErrorField").gameObject.SetActive(true);

            ComprobarCamposRequeridos();
        }
        private void InicializarComponentes() {
            InicializarPaneles();
            InicializarCamposRequeridos();
        }
        private void InicializarPaneles()
        {
            Vector3 posicionRegister = new Vector3(-288.85f, 153.35f, 0f);
            Vector3 posicionLogin = new Vector3(0f, 0f, 0f);

            // 01. Se asigna la posición de los paneles en la pantalla.
            register.transform.localPosition = posicionRegister;
            login.transform.localPosition = posicionLogin;
            register.gameObject.SetActive(false);
        }
        private void InicializarCamposRequeridos() {

            List<Dropdown.OptionData> paisesObtenidos = new List<Dropdown.OptionData>();
            List<Dropdown.OptionData> diasNacimiento = new List<Dropdown.OptionData>();
            List<Dropdown.OptionData> mesNacimiento = new List<Dropdown.OptionData>();
            List<Dropdown.OptionData> anioNacimiento = new List<Dropdown.OptionData>();
            List<Entidades.Paises> paisesEntity = new List<Entidades.Paises>();

            diasNacimiento.Add(new Dropdown.OptionData(string.Empty));
            mesNacimiento.Add(new Dropdown.OptionData(string.Empty));
            anioNacimiento.Add(new Dropdown.OptionData(string.Empty));

            paisesEntity = Cuenta.ObtenerPaises();

            foreach (Entidades.Paises pais in paisesEntity)
                paisesObtenidos.Add(new Dropdown.OptionData(pais.Pais));

            for (int diaIndex = 1; diaIndex < 32; diaIndex++)
                diasNacimiento.Add(new Dropdown.OptionData(diaIndex.ToString()));

            for (int mesIndex = 1; mesIndex < 13; mesIndex++)
                mesNacimiento.Add(new Dropdown.OptionData(mesIndex.ToString()));

            for (int anioIndex = 1999; anioIndex > 1930; anioIndex--)
                anioNacimiento.Add(new Dropdown.OptionData(anioIndex.ToString()));

            // 01. Se asignan los valores a las listas.
            paises.AddOptions(paisesObtenidos);
            dia.AddOptions(diasNacimiento);
            mes.AddOptions(mesNacimiento);
            year.AddOptions(anioNacimiento);
            createAccount.gameObject.SetActive(false);
        }
        private void ComprobarCamposRequeridos() {

            camposCompletados = true;
            foreach (Text errorField in camposRequeridos)
            {
                if (errorField.gameObject.activeSelf) {
                    camposCompletados = false;
                }
            }
            createAccount.gameObject.SetActive(camposCompletados);
        }
    }
}