﻿using Chloe.Utility;
using System;
using System.Data;

namespace Chloe.Database
{
    class InternalDataReader : IDataReader, IDisposable, IDataRecord
    {
        private InternalDbSession _dbSession;
        private IDataReader _reader;

        public InternalDataReader(InternalDbSession dbSession, IDataReader reader)
        {
            Utils.CheckNull(dbSession);
            Utils.CheckNull(reader);

            this._dbSession = dbSession;
            this._reader = reader;
        }

        #region IDataReader
        public int Depth { get { return _reader.Depth; } }
        public bool IsClosed { get { return _reader.IsClosed; } }
        public int RecordsAffected { get { return _reader.RecordsAffected; } }

        public void Close()
        {
            if (_reader != null && !_reader.IsClosed)
                _reader.Close();
            this._dbSession.Complete();
        }
        public DataTable GetSchemaTable()
        {
            return this._reader.GetSchemaTable();
        }
        public bool NextResult()
        {
            return this._reader.NextResult();
        }
        public bool Read()
        {
            return this._reader.Read();
        }

        public void Dispose()
        {
            if (this._reader != null && !this._reader.IsClosed)
                this._reader.Dispose();
            this._dbSession.Complete();
        }
        #endregion

        #region IDataRecord
        public int FieldCount { get { return this._reader.FieldCount; } }

        public object this[int i] { get { return this._reader[i]; } }
        public object this[string name] { get { return this._reader[name]; } }

        public bool GetBoolean(int i)
        {
            return this._reader.GetBoolean(i);
        }
        public byte GetByte(int i)
        {
            return this._reader.GetByte(i);
        }
        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return this._reader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }
        public char GetChar(int i)
        {
            return this._reader.GetChar(i);
        }
        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return this._reader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }
        public IDataReader GetData(int i)
        {
            return this._reader.GetData(i);
        }
        public string GetDataTypeName(int i)
        {
            return this._reader.GetDataTypeName(i);
        }
        public DateTime GetDateTime(int i)
        {
            return this._reader.GetDateTime(i);
        }
        public decimal GetDecimal(int i)
        {
            return this._reader.GetDecimal(i);
        }
        public double GetDouble(int i)
        {
            return this._reader.GetDouble(i);
        }
        public Type GetFieldType(int i)
        {
            return this._reader.GetFieldType(i);
        }
        public float GetFloat(int i)
        {
            return this._reader.GetFloat(i);
        }
        public Guid GetGuid(int i)
        {
            return this._reader.GetGuid(i);
        }
        public short GetInt16(int i)
        {
            return this._reader.GetInt16(i);
        }
        public int GetInt32(int i)
        {
            return this._reader.GetInt32(i);
        }
        public long GetInt64(int i)
        {
            return this._reader.GetInt64(i);
        }
        public string GetName(int i)
        {
            return this._reader.GetName(i);
        }
        public int GetOrdinal(string name)
        {
            return this._reader.GetOrdinal(name);
        }
        public string GetString(int i)
        {
            return this._reader.GetString(i);
        }
        public object GetValue(int i)
        {
            return this._reader.GetValue(i);
        }
        public int GetValues(object[] values)
        {
            return this._reader.GetValues(values);
        }
        public bool IsDBNull(int i)
        {
            return this._reader.IsDBNull(i);
        }
        #endregion
    }
}