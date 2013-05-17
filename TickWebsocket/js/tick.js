var resourceLib = {
    grass: "'img/grass.png'",
    trent: "'img/trent.png'"
}
var mapDiv = document.getElementById('map');
var tiles = [];
var factories = {}
factories.position = function( x, y ) {
    var position = {
        x: x,
        y: y
    }
    return position;
}
factories.htmlImageString = function( imageString ) {
	var 
} 
factories.tile = function( x, y ) {
	var ret = new Object();
	var position  = factories.position( x,y );
	getGraphic = function() {
		
	}
}

function init() {
    for( var x = 0; x < 20; x ++ ) {
        tiles[x] = [];
        for( var y = 0; y < 20; y ++ ) {
            var newPosition = factories.position(x, y);
            var newGraphic = {
                imgString: "<img  class='mapImg' src=" + resourceLib.grass + "/>"
            }

            var newOverlay = {
                graphicString: function() {
                    return "";
                }
            }
            var newTile = {
                position: newPosition,
                graphic: newGraphic,
                overlay: newOverlay,
                entities: []
            }
            tiles[x][y] = newTile;
        }
    }
}

function drawTiles() {
    mapDiv.innerHTML = "";

    for( var x = 0; x < 20; x ++ ) {
        for( var y = 0; y < 20; y ++ ) {
            var newDiv = document.createElement("div");

            newDiv.innerHTML = tiles[x][y].graphic.imgString + tiles[x][y].overlay.graphicString();
            newDiv.style.position = 'absolute';
            newDiv.style.top = (y*32) + "px";
            newDiv.style.left = (x*32) + "px";

            mapDiv.appendChild( newDiv );
        }
    }
}
function drawTrent() {
    return "<img class='mapImg' src=" + resourceLib.trent + "/>"
}
function setEnt( tile ) {
    tile.overlay.graphicString = drawTrent;
    drawTiles();
}
function setNoEnt( tile ) {
    tile.overlay.graphicString = function(){};
    drawTiles();
}

init();
drawTiles();

tiles[0][0].overlay.graphicString = drawTrent;
drawTiles();

function doMove( msg ) {
    setNoEnt( tiles[msg.fromx][msg.fromy]);
    setEnt( tiles[msg.tox][msg.toy]);
}

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
                        if( msg.item.Name == "Ted" )
                            document.getElementById("tedStatus").innerHTML = msg.item.Name + ": " + msg.item.CurHp + '/' + msg.item.Hp;
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
