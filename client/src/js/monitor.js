/* eslint-disable */
const circleNum = 100;
const degree = 360 / circleNum;
const spinNum =  4;

let p5;
let delegate;
let radius = 50;
let speed = 2;

export function main(_p5) {
  p5 = _p5

  p5.setup = _ => {
    var canvas = p5.createCanvas(850, 500)
    canvas.parent("p5Canvas");

    p5.background(255);

    radius = 0;
  }

  p5.draw = _ => {
    

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