using Apd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apd.LogicApp
{
    internal class TestScore
    {

        public static int AnxietyScore(AnsiedadTest aT)
        {
#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
            int sumAT = (int)(aT.TorpeEntumecido +
            aT.Acalorado +
            aT.TemblorPiernas +
            aT.IncapazRelajarse +
            aT.TemorOcurrirPeor +
            aT.Mareado +
            aT.LatidosFuertesAcelerados +
            aT.Inestable +
            aT.Atemorizado +
            aT.Nervioso +
            aT.SensacionBloqueo +
            aT.TembloresManos +
            aT.InquietoInseguro +
            aT.MiedoPerderControl +
            aT.SensacionAhogo +
            aT.TemorMorir +
            aT.Miedo +
            aT.ProblemasDigestivos +
            aT.Desvanecimientos +
            aT.RuborFacial +
            aT.SudoresFriosCalientes);
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.

            return sumAT;
        }


        public static int DepressionScore(DepresionTest dT)
        {
            //int cambiosHabitosSueño = dT.CambiosEnLosHabitosDeSueño == 11 ? 1 : dT.CambiosEnLosHabitosDeSueño == 21 ? 1 : dT.CambiosEnLosHabitosDeSueño == 12 ? 2 : dT.CambiosEnLosHabitosDeSueño == 22 ? 2 : dT.CambiosEnLosHabitosDeSueño == 13 ? 3 : dT.CambiosEnLosHabitosDeSueño == 23 ? 3 : 100;
            int cambiosHabitosSueño;
            switch (dT.CambiosEnLosHabitosDeSueño)
            {
                case 0:
                    cambiosHabitosSueño = 0;
                    break;
                case 11:
                case 21:
                    cambiosHabitosSueño = 1;
                    break;
                case 12:
                case 22:
                    cambiosHabitosSueño = 2;
                    break;
                case 13:
                case 23:
                    cambiosHabitosSueño = 3;
                    break;
                default:
                    cambiosHabitosSueño = 100;
                    break;
            }

            int cambiosApetito;
            switch (dT.CambiosEnElApetito)
            {
                case 0:
                    cambiosApetito = 0;
                    break;
                case 11:
                case 21:
                    cambiosApetito = 1;
                    break;
                case 12:
                case 22:
                    cambiosApetito = 2;
                    break;
                case 13:
                case 23:
                    cambiosApetito = 3;
                    break;
                default:
                    cambiosApetito = 100;
                    break;
            }

#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
            int sumaDT =
            (int)(dT.Tristeza +
            dT.Pesimismo +
            dT.Fracaso +
            dT.PerdidaDePlacer +
            dT.SentimientosDeCulpa +
            dT.DisconformidadConUnoMismo +
            dT.Autocritica +
            dT.PensamientosOdeseosSuicidas +
            dT.Llanto +
            dT.Agitacion +
            dT.PerdidaDeInteres +
            dT.Indecision +
            dT.Desvalorizacion +
            dT.PerdidaDeEnergia +

            cambiosHabitosSueño +

            dT.Irritabilidad +

            cambiosApetito +

            dT.DificultadDeConcentracion +
            dT.CansancioOfatiga +
            dT.PerdidaDeInteresSexual);
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.


            return sumaDT;
        }
    }
}
