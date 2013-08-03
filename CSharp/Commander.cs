using System.Runtime.InteropServices;
using System.Web.UI;
using CruiseControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CruiseControl
{
    public class Commander
    {
        public BoardStatus _currentBoard;
	    private List<VesselStatus> _myVessels;
	    private string[] _log = new string[50];
	    private List<Coordinate> _SonarReport;
	    private List<List<Coordinate>> _listObjects;

        public Commander()
        {
            _currentBoard = new BoardStatus();
        }

        // Do not alter/remove this method signature
        public List<Command> GiveCommands()
        {
		    var cmds = new List<Command>();
			//try
			//{
			//	ReorderVessels();

			//	// Add Commands Here.
			//	// You can only give as many commands as you have un-sunk vessels. Powerup commands do not count against this number. 
			//	// You are free to use as many powerup commands at any time. Any additional commands you give (past the number of active vessels) will be ignored.	       
			//	foreach (var vesselStatus in _currentBoard.MyVesselStatuses)
			//	{
			//		_myVessels.Add(vesselStatus);
			//	}
			//	var vesselCount = _myVessels.Count();

			//	#region Dont fall off

			//	if (_currentBoard.TurnsUntilBoardShrink == 2)
			//	{
			//		foreach (var vessel in _myVessels)
			//		{
			//			foreach (var location in vessel.Location)
			//			{
			//				if (location.X == _currentBoard.BoardMinCoordinate.X &&
			//					(location.Y == _currentBoard.BoardMinCoordinate.Y || location.Y == _currentBoard.BoardMaxCoordinate.Y))
			//				{
			//					cmds.Add(new Command {vesselid = vessel.Id, action = "move:east"});
			//					_log[_log.Count()] = "left corners";
			//				}
			//				if (location.X == _currentBoard.BoardMaxCoordinate.X &&
			//					(location.Y == _currentBoard.BoardMinCoordinate.Y || location.Y == _currentBoard.BoardMaxCoordinate.Y))
			//				{
			//					cmds.Add(new Command {vesselid = vessel.Id, action = "move:west"});
			//					_log[_log.Count()] = "right corners";
			//				}
			//			}
			//		}
			//	}
			//	if (_currentBoard.TurnsUntilBoardShrink == 1)
			//	{
			//		foreach (var vessel in _myVessels)
			//		{
			//			bool doneX = false, doneY = false;
			//			foreach (var location in vessel.Location)
			//			{
			//				if (!doneX)
			//				{
			//					if (location.X == _currentBoard.BoardMinCoordinate.X)
			//					{
			//						cmds.Add(new Command {vesselid = vessel.Id, action = "move:east"});
			//						doneX = true;
			//						_log[_log.Count()] = "left edge";
			//					}
			//					if (location.X == _currentBoard.BoardMaxCoordinate.X)
			//					{
			//						cmds.Add(new Command {vesselid = vessel.Id, action = "move:west"});
			//						doneX = true;
			//						_log[_log.Count()] = "right edge";
			//					}
			//				}
			//				if (!doneY)
			//				{
			//					if (location.Y == _currentBoard.BoardMinCoordinate.Y)
			//					{
			//						cmds.Add(new Command {vesselid = vessel.Id, action = "move:south"});
			//						doneY = true;
			//						_log[_log.Count()] = "top edge";
			//					}
			//					if (location.Y == _currentBoard.BoardMaxCoordinate.Y)
			//					{
			//						cmds.Add(new Command {vesselid = vessel.Id, action = "move:north"});
			//						doneY = true;
			//						_log[_log.Count()] = "bottom edge";
			//					}
			//				}
			//			}
			//		}
			//	}

			//	#endregion

			//	#region Run counter measures

			//	foreach (var vessel in _myVessels)
			//	{
			//		if (!vessel.CounterMeasuresLoaded && vessel.CounterMeasures > 0)
			//		{
			//			cmds.Add(new Command {vesselid = vessel.Id, action = "load_countermeasures"});
			//			_log[_log.Count()] = "deploy CM for " + vessel.Id;
			//		}
			//	}

			//	#endregion

			//	ParseSonarReport();
			//	//cmds.Add(new Command { vesselid = 1, action = "fire", coordinate = new Coordinate { X = 1, Y = 1 } });
			//	System.IO.File.WriteAllLines(@"~\log.txt", _log);
			//}
			//catch(Exception exception)
			//{
			//	Console.WriteLine(exception);
			//}
	        return cmds;
        }

        // Do NOT modify or remove! This is where you will receive the new board status after each round.
        public void GetBoardStatus(BoardStatus board)
        {
            _currentBoard = board;
        }

        // This method runs at the start of a new game, do any initialization or resetting here 
        public void Reset()
        {
			_currentBoard = new BoardStatus();
			_myVessels.Clear();
        }

		//private void ReorderVessels()
		//{
		//	var reorderedVesselList = new List<VesselStatus>();
		//	reorderedVesselList.Add(_myVessels.Find(v => v.Size == 4));
		//	reorderedVesselList.Add(_myVessels.Find(v => v.Size == 3));
		//	reorderedVesselList.Add(_myVessels.Find(v => v.Size == 5));

		//	_myVessels = reorderedVesselList;
		//}

		//private void ParseSonarReport()
		//{
		//	_SonarReport = new List<Coordinate>();
		//	foreach (var vessel in _myVessels)
		//	{
		//		foreach (var sonarCoordinate in vessel.SonarReport)
		//		{
		//			if (_SonarReport.IndexOf(sonarCoordinate) > -1)
		//				_SonarReport.Add(sonarCoordinate);
		//		}
		//	}
		//	_SonarReport.Sort();
		//	RemoveSelfFromSonar();
		//}

		//private void RemoveSelfFromSonar()
		//{
		//	foreach (var vessel in _myVessels)
		//	{
		//		foreach (var location in vessel.Location)
		//		{
		//			if (_SonarReport.IndexOf(location) > -1)
		//				_SonarReport.Remove(location);
		//		}
		//	}
		//	SortSonarCoordinates();
		//}

		//private void SortSonarCoordinates()
		//{
		//	_listObjects=new List<List<Coordinate>>();
		//	_listObjects.Add(new List<Coordinate>());
		//	_listObjects[0].Add(_SonarReport[0]);
		//	foreach (var coord in _SonarReport)
		//	{
		//		var grouped = false;
		//		if (!grouped)
		//		{
		//			foreach (var obj in _listObjects)
		//			{
		//				if (isAdjacent(obj, coord))
		//				{
		//					obj.Add(coord);
		//					grouped = true;
		//				}
		//			}
		//		}
		//	}
		//}

		//private bool isAdjacent(List<Coordinate> obj, Coordinate coord )
		//{
		//	foreach (var thing in obj)
		//	{
		//		if (thing.X == (coord.X + 1) || thing.X == (coord.X - 1) || thing.Y == (coord.Y + 1) || thing.Y == (coord.Y - 1))
		//			return true;
		//	}
		//	return false;
		//}
    }
}