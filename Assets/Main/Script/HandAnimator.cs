using UnityEngine;
using UnityEngine.UI;
using Klak.TestTools;
using MediaPipe.HandPose;

public sealed class HandAnimator : MonoBehaviour
{
    public Vector3 Thumb_0, Thumb_1, Thumb_2, Thumb_3, Thumb_4;
    public Vector3 Index_0, Index_1, Index_2;
    public Vector3 Middle_0, Middle_1, Middle_2;
    public Vector3 Ring_0, Ring_1, Ring_2;
    public Vector3 Pinky_0, Pinky_1, Pinky_2;
    public Vector3 Palm_0, Palm_1, Palm_2, Palm_3, Palm_4;
    public GameObject steeringWheel;
    float preangle = 0f;
    float angle;
    //float angle;
    #region Editable attributes

    [SerializeField] ImageSource _source = null;
    [Space]
    [SerializeField] ResourceSet _resources = null;
    [SerializeField] bool _useAsyncReadback = true;
    [Space]
    [SerializeField] Mesh _jointMesh = null;
    [SerializeField] Mesh _boneMesh = null;
    [Space]
    [SerializeField] Material _jointMaterial = null;
    [SerializeField] Material _boneMaterial = null;
    [Space]
    [SerializeField] RawImage _monitorUI = null;

    #endregion

    #region Private members

    HandPipeline _pipeline;

    static readonly (int, int)[] BonePairs =
    {
        (0, 1), (1, 2), (1, 2), (2, 3), (3, 4),     // Thumb
        (5, 6), (6, 7), (7, 8),                     // Index finger
        (9, 10), (10, 11), (11, 12),                // Middle finger
        (13, 14), (14, 15), (15, 16),               // Ring finger
        (17, 18), (18, 19), (19, 20),               // Pinky
        (0, 17), (2, 5), (5, 9), (9, 13), (13, 17)  // Palm
    };

    Matrix4x4 CalculateJointXform(Vector3 pos)
      => Matrix4x4.TRS(pos, Quaternion.identity, Vector3.one * 0.07f);

    Matrix4x4 CalculateBoneXform(Vector3 p1, Vector3 p2)
    {
        var length = Vector3.Distance(p1, p2) / 2;
        var radius = 0.03f;

        var center = (p1 + p2) / 2;
        var rotation = Quaternion.FromToRotation(Vector3.up, p2 - p1);
        var scale = new Vector3(radius, length, radius);

        return Matrix4x4.TRS(center, rotation, scale);
    }

    #endregion

    #region MonoBehaviour implementation

    void Start()
      => _pipeline = new HandPipeline(_resources);

    void OnDestroy()
      => _pipeline.Dispose();

    void LateUpdate()
    {
        // Feed the input image to the Hand pose pipeline.
        _pipeline.UseAsyncReadback = _useAsyncReadback;
        _pipeline.ProcessImage(_source.Texture);

        var layer = gameObject.layer;

        // Joint balls
        for (var i = 0; i < HandPipeline.KeyPointCount; i++)
        {
            var xform = CalculateJointXform(_pipeline.GetKeyPoint(i));
            Graphics.DrawMesh(_jointMesh, xform, _jointMaterial, layer);
        }

        // Bones
        foreach (var pair in BonePairs)
        {
            var p1 = _pipeline.GetKeyPoint(pair.Item1);
            var p2 = _pipeline.GetKeyPoint(pair.Item2);
            var xform = CalculateBoneXform(p1, p2);
            Graphics.DrawMesh(_boneMesh, xform, _boneMaterial, layer);
        }

        // UI update
        _monitorUI.texture = _source.Texture;
    }

    #endregion

    public static float Vector2ToAngle(Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }

    // これ多分　thumb の　座標
    private void Update() {
      Thumb_0 = _pipeline.GetKeyPoint(BonePairs[0].Item1);
      Thumb_1 = _pipeline.GetKeyPoint(BonePairs[1].Item1);
      Thumb_2 = _pipeline.GetKeyPoint(BonePairs[2].Item1);
      Thumb_3 = _pipeline.GetKeyPoint(BonePairs[3].Item1);
      Thumb_4 = _pipeline.GetKeyPoint(BonePairs[4].Item1);

      Index_0 = _pipeline.GetKeyPoint(BonePairs[5].Item1);
      Index_1 = _pipeline.GetKeyPoint(BonePairs[6].Item1);
      Index_2 = _pipeline.GetKeyPoint(BonePairs[7].Item1);

      Middle_0 = _pipeline.GetKeyPoint(BonePairs[8].Item1);
      Middle_1 = _pipeline.GetKeyPoint(BonePairs[9].Item1);
      Middle_2 = _pipeline.GetKeyPoint(BonePairs[10].Item1);
      
      Ring_0 = _pipeline.GetKeyPoint(BonePairs[11].Item1);
      Ring_1 = _pipeline.GetKeyPoint(BonePairs[12].Item1);
      Ring_2 = _pipeline.GetKeyPoint(BonePairs[13].Item1);

      Pinky_0 = _pipeline.GetKeyPoint(BonePairs[14].Item1);
      Pinky_1 = _pipeline.GetKeyPoint(BonePairs[15].Item1);
      Pinky_2 = _pipeline.GetKeyPoint(BonePairs[16].Item1);

      Debug.Log(Thumb_0);
        //Vector2 hand = new Vector2(Thumb_4.x, Thumb_4.y);
      angle = Mathf.Atan2(Thumb_0.x, Thumb_0.y) * Mathf.Rad2Deg;
      Debug.Log(-(angle - preangle));
      steeringWheel.transform.Rotate(0, -(angle - preangle), 0);
      preangle = angle;
            //steeringWheel.transform.eulerAngles = new Vector3(0, 0, -angle);
       // steeringWheel.transform.rotation = Quaternion.AngleAxis(-angle, new Vector3(0, 0, 1));


        // GameObject testobject = Instantiate(collisionPrefab);
        // testobject.transform.position = ptest;
    }

}
