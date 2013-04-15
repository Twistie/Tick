using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql;
using MySql.Data.MySqlClient;
using Tick.typeClasses;


namespace Tick
{

    class MySQLSaveLoad : ISaveLoad
    {
        private Entity _curEntity;
        private Character _curChar;
        private Area _curArea;
        private readonly MySqlConnection _mySqlCon;
        private readonly ILogger _logger;
        private MySqlDataReader _curData;

        public MySQLSaveLoad(ILogger logger)
        {
            _logger = logger;

            const string cs = @"server=192.168.0.3;userid=TickServ;
            password=password;database=TICK";

            _mySqlCon = null;

            try
            {
                _mySqlCon = new MySqlConnection(cs);
                _mySqlCon.Open();
                _logger.Log("MySQL version : "+  _mySqlCon.ServerVersion);

            }
            catch (MySqlException ex)
            {
                _logger.Log("Error: "+  ex.ToString());

            }
        }

        public void StartSave()
        {
            return;
        }

        public void EndSave()
        {
            return;
        }

        public void StartEntity( Entity e,  bool isChar)
        {
            _curEntity = e;
            if (e.ID == 0 )
            {
                ExecuteStatement("INSERT INTO ENTITYS (ID) VALUES (NULL)");
                e.ID = LastIdGen();
            }
            if(!CheckExist(e.ID, "ENTITYS")) {
                ExecuteStatement(String.Format("INSERT INTO ENTITYS (ID) VALUES (%i)", e.ID));
            }

            ExecuteStatement(generateSQLForUpdateEntity(e));
        }

        public String generateSQLForUpdateEntity(Entity e)
        {
            if (e.Owner == null)
            {
                return String.Format("UPDATE ENTITYS SET x = {0}, y = {1} WHERE id = {2}", e.Location.X, e.Location.Y, e.ID);
            }
            else
            {
                return String.Format("UPDATE ENTITYS SET x = {0}, y = {1}, owner = \"NULL\" WHERE id = {2}", e.Location.X, e.Location.Y, e.ID);
            }
        }

        public void EndEntity()
        {
            /*throw new NotImplementedException();*/
        }

        public void StartChar(Character c)
        {
            throw new NotImplementedException();
        }

        public void EndChar()
        {
            throw new NotImplementedException();
        }
        public List<Character> LoadChars()
        {
            return null;
        }

        public void StartArea(int x, int y)
        {
            //Nothing to store at this point
            //throw new NotImplementedException();
        }

        public void EndArea()
        {
            //Nothing to store at this point
            //throw new NotImplementedException();
        }

        private Boolean CheckExist( int id, string table )
        {
            String sendString = string.Format("SELECT ID FROM {0} WHERE ID={1};", table, id);
            return ExecuteStatement(sendString).HasRows;
        }

        private MySqlDataReader ExecuteStatement(string s )
        {
            if( _curData != null && !_curData.IsClosed )
            {
                _curData.Close();
            }
            MySqlCommand curCom = new MySqlCommand(s, _mySqlCon);
            _curData = curCom.ExecuteReader();
            if (_curData.Read())
            {
                int i = _curData.GetInt32(0);
            }
            
            return _curData;
        }

        private int LastIdGen()
        {
            return (ExecuteStatement("SELECT LAST_INSERT_ID()").GetInt32(0));
        }

        
        
    }
}
