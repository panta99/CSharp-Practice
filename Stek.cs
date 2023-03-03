using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezbanjeStack.BusinessLayer
{
    public class Stek<T> : IEnumerable<T>, IEnumerable
    {
        private T[] stavke;
        private int vrh = -1;
        public const int PodrazumevaniKapacitet = 8;
        public const int PodrazumevanoPovecanje = 2;
        public Stek(int pocetniKapacitet = PodrazumevaniKapacitet)
        {
            this.stavke = new T[pocetniKapacitet];
        }
        public void DodajNaStek(T item)
        {
            if (this.vrh == this.stavke.Length - 1)
                this.PovecajKapacitet();
            vrh++;
            this.stavke[vrh] = item;
        }
        public void PovecajKapacitet(int n = PodrazumevanoPovecanje)
        {
            if (n < PodrazumevaniKapacitet)
                n = PodrazumevaniKapacitet;
            T[] tmpStavke = new T[this.stavke.Length*n];
            Array.Copy(this.stavke, tmpStavke, this.stavke.Length);
            this.stavke = tmpStavke;
        }

        public T SkiniSaSteka()
        {
            if (vrh < 0)
                throw new InvalidOperationException();
            return this.stavke[vrh--];
        }
        public T DohvatiSaSteka()
        {
            if (vrh < 0)
                throw new InvalidOperationException();
            return this.stavke[vrh];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(this.stavke, this.vrh);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
   public class StackEnumerator<T> : IEnumerator<T>, IEnumerator
    {
        private T[] stavke;
        private int vrh = -1;
        private int indeks;
        public StackEnumerator(T[] stavke, int vrh)
        {
            this.stavke = stavke;
            this.vrh = vrh;
            this.indeks = vrh + 1;
        }

        public T Current
        {
            get
            {
                if ((indeks < 0) || indeks > vrh)
                    throw new IndexOutOfRangeException();
                return this.stavke[indeks];
            }
        }

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            indeks--;
            return indeks >= vrh;
        }

        public void Reset()
        {
            indeks = vrh +1;
        }
    }
    }
  
    

