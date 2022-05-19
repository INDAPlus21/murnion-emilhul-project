using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamComponent : HexComponent
{
    Direction dir;
    int length;

    public override void Init(int _length, Direction _dir) {
        length = _length;
        dir = _dir;
    }

    public override void Debug()
    {
        UnityEngine.Debug.Log(dir);
        UnityEngine.Debug.Log(length);
    }

    void Update() {

    }

    public override Dictionary<(int, int), (int, int)> Activate(Function c) {
        Dictionary<(int, int), (int, int)> moves = new Dictionary<(int, int), (int, int)>();
        switch (c) {
            case Function.Push:
                for (int i = 0; i < length; i++) {
                    moves.Add(MultiplyTupleByScalar(DirectionToTuple(dir), i), MultiplyTupleByScalar(DirectionToTuple(dir), i+1));
                }
                break;
            case Function.Pull:
                for (int i = 0; i < length - 1; i++) {
                    moves.Add(MultiplyTupleByScalar(DirectionToTuple(dir), i+1), MultiplyTupleByScalar(DirectionToTuple(dir), i));
                }
                break;
            case Function.RotateRight:
                switch (this.dir) {
                    case Direction.East:
                        this.dir = Direction.Southeast;
                        break;
                    case Direction.Northeast:
                        this.dir = Direction.East;
                        break;
                    case Direction.Southeast:
                        this.dir = Direction.Southwest;
                        break;
                    case Direction.West:
                        this.dir = Direction.Northwest;
                        break;
                    case Direction.Northwest:
                        this.dir = Direction.Northeast;
                        break;
                    case Direction.Southwest:
                        this.dir = Direction.West;
                        break;
                }
                break;
            case Function.RotateLeft:
                switch (this.dir) {
                    case Direction.Southeast:
                        this.dir = Direction.East;
                        break;
                    case Direction.East:
                        this.dir = Direction.Northeast;
                        break;
                    case Direction.Southwest:
                        this.dir = Direction.Southeast;
                        break;
                    case Direction.Northwest:
                        this.dir = Direction.West;
                        break;
                    case Direction.Northeast:
                        this.dir = Direction.Northwest;
                        break;
                    case Direction.West:
                        this.dir = Direction.Southwest;
                        break;
                }
                break;
            default:
                break;
        }

        float rotation = 0f;
        switch (this.dir) {
            case Direction.East:
            case Direction.West:
                break;
            case Direction.Northeast:
            case Direction.Southwest:
                rotation = 60f;
                break;
            case Direction.Southeast:
            case Direction.Northwest:
                rotation = 120f;
                break;
        }
        this.transform.eulerAngles = new Vector3(
            0f,
            0f,
            rotation
        );

        return moves;
    }
    
    public (int, int) DirectionToTuple(Direction d) {
        switch (d) {
            case Direction.East:
                return (1, 0);
            case Direction.Northeast:
                return (0, 1);
            case Direction.Southeast:
                return (1, -1);
            case Direction.West:
                return (-1, 0);
            case Direction.Northwest:
                return (-1, 1);
            case Direction.Southwest:
                return (0, -1);
            default:
                return (0, 0);
        }
    }

    public (int, int) MultiplyTupleByScalar((int, int) t, int s) {
        return (t.Item1 * s, t.Item2*s);
    }
}

