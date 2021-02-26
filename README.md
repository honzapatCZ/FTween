# FTween
Simple to use tweening library for flax.

![Main](https://raw.githubusercontent.com/honzapatCZ/FTween/master/imgs/ftween-simple.gif)

## As simple as doing

```cs
using using FTween;

Actor.FTLocalMoveY(100, 5).Start();
```

## Numerous extensions

Checkout your ide or /Extension/Extensions.cs

## Supports Sequences

![Sequence](https://raw.githubusercontent.com/honzapatCZ/FTween/master/imgs/ftween-sequence.gif)

```cs
Sequence seq = new Sequence();
seq.Append(Actor.FTLocalMoveY(100, 5));
seq.Insert(actor2.FTLocalMoveY(100, 5));

seq.Append(Actor.FTLocalMoveX(100, 5));
seq.Insert(Actor.FTLocalMoveZ(100, 5));
seq.Insert(actor2.FTLocalMoveX(-100,5));
seq.Insert(actor2.FTLocalMoveZ(-100, 5));
                        
seq.Append(Actor.FTLocalMoveY(300, 5));
seq.Insert(actor2.FTLocalMoveY(300, 5));

seq.OnComplete(() => { Debug.Log("Sequence ended"); });
seq.Start();
```

## Supports await

Super easy

![Sequence](https://raw.githubusercontent.com/honzapatCZ/FTween/master/imgs/ftween-await.gif)

```cs
Debug.Log("Starting test");

Debug.Log("Moving along X");
await Actor.FTLocalMoveX(100, 5).Start();
Debug.Log("Done");

Debug.Log("Moving along Y");
await Actor.FTLocalMoveY(100, 5).Start();
Debug.Log("Done");

Debug.Log("Moving along Z");
await Actor.FTLocalMoveZ(100, 5).Start();
Debug.Log("Done");

Debug.Log("Rotating");
await Actor.FTRotateQuaternion(Quaternion.Euler(5, 45, 45), 5).Start();
Debug.Log("Done");
```
