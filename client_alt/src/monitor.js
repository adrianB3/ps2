/* eslint-disable */


let p5;
let delegate;
let radius = 50;
let speed = 2;
let pump1State = false;
let pump2State = false;
let pump3State = false;
let pump4State = false;

let waterLevel1 = false;
let waterLevel2 = false;
let waterLevel3 = false;
let waterLevel4 = false;


export function main(_p5) {
    p5 = _p5

    p5.setup = _ => {
        var canvas = p5.createCanvas(800, 700)
        canvas.parent("p5Canvas");

        p5.background(180);
        p5.rectMode(p5.CENTER)

    };

    p5.draw = _ => {

        p5.strokeWeight(1);
        if(pump1State == true)
            p5.fill('red');
        else
            p5.fill('white')
        let pump1 = p5.ellipse(150,500,60,60);

        p5.fill('black');
        p5.text('M1', 95, 500);
        p5.triangle(150, 470, 138, 485, 162, 485);
        p5.line(180, 495, 195, 495);
        p5.line(180, 505, 195, 505);
        p5.fill('white');
        p5.triangle(150,545, 138, 565, 162, 565);
        p5.rect(150, 575, 10, 20);

        if(pump2State == true)
            p5.fill('red');
        else
            p5.fill('white')
        let pump2 = p5.ellipse(300,500,60,60);
        p5.fill('black');
        p5.text('M2', 245, 500);
        p5.triangle(300, 470, 288, 485, 312, 485);
        p5.line(330, 495, 345, 495);
        p5.line(330, 505, 345, 505);
        p5.fill('white');
        p5.triangle(300,545, 288, 565, 312, 565);
        p5.rect(300, 575, 10, 20)

        if(pump3State == true)
            p5.fill('red');
        else
            p5.fill('white')
        let pump3 = p5.ellipse(450,500,60,60);
        p5.fill('black');
        p5.text('M3', 395, 500);
        p5.triangle(450, 470, 438, 485, 462, 485);
        p5.line(480, 495, 495, 495);
        p5.line(480, 505, 495, 505);
        p5.fill('white');
        p5.triangle(450,545, 438, 565, 462, 565);
        p5.rect(450, 575, 10, 20);


        if(pump4State == true)
            p5.fill('red');
        else
            p5.fill('white')
        let pump4 = p5.ellipse(600,500,60,60);
        p5.fill('black');
        p5.text('M4', 545, 500);
        p5.triangle(600, 470, 588, 485, 612, 485);
        p5.line(630, 495, 645, 495);
        p5.line(630, 505, 645, 505);
        p5.fill('white');
        p5.triangle(600,545, 588, 565, 612, 565);
        p5.rect(600, 575, 10, 20);


        p5.fill('white');
        p5.rect(380, 305, 100, 250, 0);

        // adding water
        if(waterLevel4 == true)
            p5.fill('blue')
        else
            p5.fill('white')
        p5.rect(380, 390, 100, 80, 0);

        if(waterLevel2 == true)
            p5.fill('blue')
        else
            p5.fill('white')
        p5.rect(380, 315, 100, 70, 0);

        if(waterLevel1 == true)
            p5.fill('blue')
        else
            p5.fill('white')
        p5.rect(380, 250, 100, 60, 0);

        if(waterLevel3 == true)
            p5.fill('blue')
        else
            p5.fill('white')
        p5.rect(380, 205, 100, 30, 0);

        p5.fill('white')
        p5.ellipse(370,420,10,10);
        p5.line(364, 420, 250, 420);
        p5.rect(250, 420, 35, 35);
        p5.line(232, 420, 190, 420);

        p5.fill('black');
        p5.line(280, 350, 330, 350);
        p5.line(430, 220, 480, 220);
        p5.line(430, 280, 480, 280);
        p5.line(280, 200, 330, 200);
        p5.text('B4', 260, 355);
        p5.text('B3', 260, 205);
        p5.text('B1', 490, 225);
        p5.text('B2', 490, 285);
        p5.text('U1', 165, 425);
        p5.line(430, 380, 480, 380);
        p5.text('Y1', 490, 385);
        p5.text('0...10V', 190, 415);

        p5.fill('black');

        p5.strokeWeight(4);
        p5.line(150,455,600,455);

        p5.fill('black');

        p5.strokeWeight(4);
        p5.line(150,455,150,470);
        p5.line(150,530,150,545);

        p5.strokeWeight(4);
        p5.line(300,455,300,470);
        p5.line(300,530,300,545);

        p5.strokeWeight(4);
        p5.line(450,455,450,470);
        p5.line(450,530,450,545);

        p5.strokeWeight(4);
        p5.line(600,455,600,470);
        p5.line(600,530,600,545);

        p5.strokeWeight(4);
        p5.line(380,455,380,430);

        p5.strokeWeight(0.5);
        p5.line(145,555,605,555);
        p5.line(145,560,605,560);
        p5.line(145,565,605,565);
        p5.line(145,570,605,570);
        p5.line(145,575,605,575);
        p5.line(145,580,605,580);
        p5.line(145,585,605,585);
        p5.line(145,590,605,590);
        p5.line(145,595,605,595);
        p5.line(145,600,605,600);

        p5.fill('white');
        p5.rect(350, 130, 10, 20)
        p5.line(350,139,350,150);
        p5.line(350,109,350,120);
        if(waterLevel1 == true)
            p5.fill('red')
        else
            p5.fill('white')
        p5.triangle(420, 115, 355, 135, 400, 150);

        notifyCurrentTime();
    }
}

function notifyCurrentTime() {
    if (delegate !== undefined) {
        const message = p5.hour() + ":" + p5.minute() + ":" + p5.second();

        delegate(message);
    }
}

export function setDelegate(_delegate) {
    delegate = _delegate;
}

export function getData(pump1St, pump2St, pump3St, pump4St, wl1, wl2, wl3, wl4) {
    pump1State = pump1St;
    pump2State = pump2St;
    pump3State = pump3St;
    pump4State = pump4St;

    waterLevel1 = wl1;
    waterLevel2 = wl2;
    waterLevel3 = wl3;
    waterLevel4 = wl4;
}