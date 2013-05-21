var resourceLib = {
    grass: "'img/grass.png'",
    trent: "'img/trent.png'",
    fight: "'img/fight.png'"
}
var mapDiv = document.getElementById('map');
var controlDiv = document.getElementById('controls');
var tiles = [];
var factories = {};
var selectedEntity = null;
var entities = new Object();
var status = "init";
var routeList = [];

factories.position = function( x, y ) {
    var position = {
        x: x,
        y: y
    }
    return position;
}
factories.entity = function( id, stats ) {
	var entity = new Object();
	
	entity.id = id;
	entity.stats = stats;
	return entity;
}
factories.htmlImageString = function( imageString ) {
	return "<img  class='mapImg' src=" + imageString + "/>";
} 
factories.tile = function( x, y ) {
	var tile = new Object();
	tile.position  = factories.position( x,y );
	tile.entities = [];
	tile.getGraphic = function() {
		return this.getBackgroundString() + this.getOverlayString();
	}
	var bgString = factories.htmlImageString( resourceLib.grass );
	
	tile.getBackgroundString = function() {
		return bgString;
	}
	tile.getOverlayString = function() {
		if( this.entities.length > 0 ) {
			if( !entities[this.entities[0].id].stats.IsInCombat ) {
				return factories.htmlImageString( resourceLib.trent );
			}else {
				return factories.htmlImageString( resourceLib.fight );
			}
		}
		return "";
	}
	tile.position = factories.position(x,y);
	tile.onclick = function( e ) { 
		console.log( this.tile.position.x + " : " + this.tile.position.y );
		if( status == "recordRoute" ) {
			addRouteLocation( this.tile.position.x, this.tile.position.y );
			return;
		}
		if( this.tile.entities.length > 0)
		{
			selectedEntity =this.tile.entities[0];
			updateStatus( selectedEntity );
			controlDiv.innerHTML = "<input type='button' value='Start Route' onclick='startRoute()'/>";
		}
	}
	return tile;
}
function addRouteLocation(x, y) {
	var newloc = x + ":" +y;
	routeList.push(newloc);
	var html = "<H3>Click on the map to make a route</H3> <BR/><input type='button' value='Commit' onclick='resetRoute()'><BR> Route so far <BR> <OL>"
	for( var i in routeList ) {
		html += "<LI>"+routeList[i]+"</LI>";
	}
	html += "</OL>";
	controlDiv.innerHTML = html;
}
function resetRoute() {
	var msg = new Object();
	msg.args = new Object();
	msg.args.moveList = routeList.toString();
	msg.args.Id = selectedEntity.id;
	msg.type = "moveRoute";
	ws.send( JSON.stringify(msg));
	controlDiv.innerHTML = "<input type='button' value='Start Route' onclick='startRoute()'/>";
}
function startRoute() {
	status = "recordRoute";
	routeList = [];
	controlDiv.innerHTML = "<H3>Click on the map to make a route</H3><BR/><input type='button' value='Reset' onclick='resetRoute()'>";
}

function init() {
    for( var x = 0; x < 20; x ++ ) {
        tiles[x] = [];
        for( var y = 0; y < 20; y ++ ) {
            tiles[x][y] = factories.tile(x,y);
        }
    }
    status = "1"
}
init();
function drawTiles() {
    mapDiv.innerHTML = "";

    for( var x = 0; x < 20; x ++ ) {
        for( var y = 0; y < 20; y ++ ) {
            var newDiv = document.createElement("div");

            newDiv.innerHTML = tiles[x][y].getGraphic();
            newDiv.style.position = 'absolute';
            newDiv.style.top = (y*32) + "px";
            newDiv.style.left = (x*32) + "px";
            newDiv.tile =  tiles[x][y];

            mapDiv.appendChild( newDiv );
            newDiv.onclick = tiles[x][y].onclick;
        }
    }
}
function drawTrent() {
    return "<img class='mapImg' src=" + resourceLib.trent + "/>"
}
function addEnt( tile, entity ) {
    tile.entities.push( entity );
    drawTiles();
}
function removeEnt( tile, entity ) {
	for( var i = 0; i < tile.entities.length ; i++ ) {
		if( tile.entities[i].id == entity.id ) 
		{
    		tile.entities.splice(i, 1);
    		i--;
    	}
    }
	drawTiles();
}
function resetEntityLocs() {
	for( var i in tiles ) {
		for( var n in tiles[i] ) {
			tiles[i][n].entities = [];
		}
	}
	
	drawTiles();
}
function updateStatus( entity ) {
	document.getElementById("tedStatus").innerHTML = entity.stats.Name + ": " + entity.stats.CurHp + '/' + entity.stats.Hp;
}

function doMove( msg, entity ) {
	if( !entities[msg.ent] ) {
		var smsg = new Object();
		smsg.type = "entityRequest";
		smsg.args = new Object();
		smsg.args.Id = msg.ent;
		ws.send( JSON.stringify(smsg) );
		resetEntityLocs()
	}else
	{
	    removeEnt( tiles[msg.fromx][msg.fromy], entities[msg.ent]);
	    
	    addEnt( tiles[msg.tox][msg.toy], entities[msg.ent]);
   }
}





drawTiles();


var ws;
if ("WebSocket" in window) {
    ws = new WebSocket("ws://123.243.99.188:8081/");
    ws.onopen = function() {
        // Web Socket is connected. You can send data by send() method.
    };
    ws.onmessage = function (evt) {
        var received_msg = evt.data;
        try {
            var msg = $.parseJSON(received_msg);
            //alert( received_msg);
            if( msg.type ) {
                switch( msg.type ) {
                    case "move":
                        doMove( msg );
                        break;
                    case "status":
                        msg.item =  $.parseJSON(msg.item);
                        entities[ msg.item.Id ] = factories.entity( msg.item.Id, msg.item );
                    	if( selectedEntity  && selectedEntity.id == msg.item.Id ) {
                        	selectedEntity = entities[ msg.item.Id ];
                    		updateStatus(selectedEntity );
                    	}
                        drawTiles();
                        break;
                }
            }
        } catch ( e ) {
            document.getElementById('log').innerHTML = evt.data + "<BR>" + document.getElementById('log').innerHTML;
        }
    };
    ws.onclose = function(evt) {
        alert("Websocket closed" + evt );
    };
} else {
    // the browser doesn't support WebSocket.
}
