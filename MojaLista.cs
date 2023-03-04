using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezbanjeGenerickaLista1.BusinessLayer
{
    public class MojaLista<T> : IEnumerable<T>, IEnumerable
    {
        private T[] items;
        private int count;
        public const int PodrazumevaniKapacitet = 8;
        public const int PodrazumevanoPovecanje = 2;

        public int Count => this.count;
        public T this[int indeks]
        {
            get
            {
                if ((indeks < 0) || (indeks >= this.items.Length))
                    throw new IndexOutOfRangeException();
                return this.items[indeks];
            }
            set
            {
                if ((indeks < 0) || (indeks >= this.items.Length))
                    throw new IndexOutOfRangeException();
                this.items[indeks] = value;
            }
        }
        public MojaLista()
        {
            this.items = new T[PodrazumevaniKapacitet];
        }
        public MojaLista(int kapacitet)
        {
            if (kapacitet < PodrazumevaniKapacitet)
                kapacitet = PodrazumevaniKapacitet;
            this.items = new T[PodrazumevaniKapacitet];
        }
        public void PovecajKapacitet(int n = PodrazumevanoPovecanje)
        {
            if (n < PodrazumevanoPovecanje)
                n = PodrazumevanoPovecanje;
            T[] tmpItems = new T[this.items.Length*n];
            Array.Copy(this.items, tmpItems, this.items.Length);
            this.items = tmpItems;
        }
        public void Add(T item)
        {

            if (this.items.Length == count)
                PovecajKapacitet();
            this.items[count++] = item;
        }
        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
                this.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorZaMojuListu<T>(this.items, this.count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    public class EnumeratorZaMojuListu<T> : IEnumerator<T>, IEnumerator
    {
        private T[] items;
        private int count;
        private int tekuci = -1;
        public EnumeratorZaMojuListu(T[] items,int count)
        {
            this.items = items;
            this.count = count;
        }

        public T Current
        {
            get
            {
                if ((this.tekuci < 0) || (this.tekuci > this.count))
                    throw new InvalidOperationException();
                return this.items[this.tekuci];
            }
        }
        object IEnumerator.Current => this.Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            this.tekuci++;
            return this.tekuci < this.count;
        }

        public void Reset()
        {
            this.tekuci = -1;
        }
    }
}
