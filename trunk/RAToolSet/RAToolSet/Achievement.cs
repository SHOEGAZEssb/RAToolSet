using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAToolSet
{
  class Achievement
  {
    int _id;
    int _numAwarded;
    int _numAwardedHardcore;
    string _title;
    string _description;
    int _points;
    int _trueRatio; //??
    string _author; //evtl User-Klasse?
    string _dateModified;
    string _dateCreated;
    int _badgeID;
    int _displayOrder;

    public Achievement(int id, int numAwarded, int numAwardedHardcore, string title, string description, int points, int trueRatio, string author,
                       string dateModified, string dateCreated, int badgeID, int displayOrder)                       
    {
      _id = id;
      _numAwarded = numAwarded;
      _numAwardedHardcore = numAwardedHardcore;
      _title = title;
      _description = description;
      _points = points;
      _trueRatio = trueRatio;
      _author = author;
      _dateModified = dateModified;
      _dateCreated = dateCreated;
      _badgeID = badgeID;
      _displayOrder = displayOrder;
    }
  }
}
