using System;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos
{
    public class ISINMatch : IEquatable<ISINMatch>
    {
        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                if (value.Length == 12)
                {
                    ISIN = value;
                    return;
                }
                _symbol = value;
            }
        }

        private string _isin;
        public string ISIN
        {
            get { return _isin; }
            set
            {
                if (value.Length != 12)
                {
                    Symbol = value;
                    return;
                }
                _isin = value;
            }
        }

        public bool Equals(ISINMatch other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_symbol, other._symbol) && string.Equals(_isin, other._isin);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ISINMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_symbol != null ? _symbol.GetHashCode() : 0)*397) ^ (_isin != null ? _isin.GetHashCode() : 0);
            }
        }

        public static bool operator ==(ISINMatch left, ISINMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ISINMatch left, ISINMatch right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Symbol: {0}, ISIN: {1}", Symbol, ISIN);
        }
    }
}