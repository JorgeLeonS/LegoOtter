    using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Otter{
    public class Brick : MonoBehaviour
    {

        public GameObject singlePrefab;
        public GameObject singleSmallBrownPrefab;
        public GameObject singleSmallBeigePrefab;
        public GameObject diagonalPrefab;
        public GameObject circleSmallPrefab;
        public GameObject single2x1Prefab;
        public GameObject neckBasePrefab;
        public GameObject singleFlatPrefab;

        //New Movement Prefabs
        public GameObject neckConnectionPrefab;
        public GameObject newsingle2x1Prefab;
        public GameObject newSinglePrefab;
        public GameObject small3x1Prefab;
        public GameObject noseBasePrefab;
        public GameObject noseDotPrefab;
        public GameObject singleWSidePrefab;
        public GameObject eyePiecePrefab;
        public GameObject halfTrianglePrefab;
        public GameObject newSingleSmallPrefab;
        public GameObject small1x2Prefab;

        public GameObject flat1x2Prefab; 

        public int step;
        public int count;

        bool animate;

        // NEWHeadMovement
        // NeckConnection
        SinglePiece newNeckConnection;
        //BottomSingles
        SinglePiece flatMiddle1;
        SinglePiece flatMiddle2;
        // Bottom
        Flat3x1 flat3x1;
        SinglePiece bottomSingle1;
        SinglePiece bottomNoseConnection;
        SinglePiece noseDot;
        SinglePiece bottomSingle2;
        // Middle
        SinglePiece backMiddleSingle1;
        SinglePiece backMiddleSingle2;
        SinglePiece backMiddleSingle3;
        SinglePiece eyeConnection1;
        SinglePiece eyeConnection2;
        SinglePiece middleSingle;
        SinglePiece eye1;
        SinglePiece eye2;
        // Top1
        Flat3x1 flat3x1Top;
        SinglePiece topSingle1;
        SinglePiece topSingle2;
        SinglePiece topSingle3;
        // Top2
        SinglePiece backTopSmall;
        SinglePiece halfTriangle;
        Flat1x2 flat1x21;
        Flat1x2 flat1x22;
        // Tail
        Flat3x1 tailStart;
        Flat1x2 tailNext;

        Matrix4x4 translateNeckConnection;
        Matrix4x4 transformNeckConnection;

        Matrix4x4 translateTailConnection;
        Matrix4x4 transformTailConnection;

        bool headAnimation = false;

        float neckRot = 0.0f;
        float neckDir = 1.0f;

        float tailRot = 0.0f;
        float tailDir = 1.0f;
        //Matrix Operations for Head
        // Matrix4x4 translateConnector;
        // Matrix4x4 transformConnector;
        //Matrix Operation for Tail
    

        Otter.BasicLego bl1;
        List<Otter.BasicLego[]> Pieces = new List<Otter.BasicLego[]>();
        // Otter.BasicLego[] headPieces = new Otter.BasicLego[2];

        Matrix4x4 right = Otter.MatrixOperations.opTranslate(2,0,0);
        Matrix4x4 down = Otter.MatrixOperations.opTranslate(0,0,-2);
        Matrix4x4 up = Otter.MatrixOperations.opTranslate(2,0,0);

        GameObject particleSystemObject;
        ParticleEmitter particleSystem;

        // Start is called before the first frame update
        void Start()
        {
            particleSystemObject = GameObject.Find("ParticleEmitter");
            particleSystem = particleSystemObject.GetComponent<ParticleEmitter>();
            animate = false;
            // // Step1
            // small2x8();
            // //Step2
            // //RightSide
            // movePiece(doubleDiagonal(), 0,1.3f,-2);
            // movePiece(doubleDiagonal(), 0,1.3f,-6);
            // movePiece(doubleDiagonal(), 0,1.3f,-10);
            // //LeftSide
            // movePiece(doubleDiagonal180(), 2,1.3f,-2);
            // movePiece(doubleDiagonal180(), 2,1.3f,-6);
            // movePiece(doubleDiagonal180(), 2,1.3f,-10);
            // //Tail
            // movePiece(doubleDiagonal90(), 2,1.3f,0);

            // //Step3
            // movePiece(small2x1(), 0,2.5f,-12);
            // movePiece(small2x1(), 4,2.5f,-12);

            // movePiece(regular1x2(singlePrefab), -2,3.2f,-8);
            // movePiece(regular1x2(singlePrefab), 4,3.2f,-8);

            // movePiece(small1x4(), -2,2.5f,0);
            // movePiece(small1x4(), 4,2.5f,0);
            // //BeigeCenter
            // movePiece(small2x4(singleSmallBeigePrefab), 0,2.5f,-4);

            // //Step4
            // movePiece(singlePiece(circleSmallPrefab),3.5f,4.5f,-11.2f);
            // movePiece(singlePiece(circleSmallPrefab),-1f,4.5f,-11.2f);
        
            // movePiece(singlePiece90(diagonalPrefab),4,3.8f,0);
            // movePiece(singlePiece90(diagonalPrefab),-2,3.8f,0);

            // //NeckBase
            // movePiece(singlePiece180(neckBasePrefab),1,1.3f,-14);

            // //Tail
            // movePiece(singlePiece(single2x1Prefab), 1,2.6f,2);
            // movePiece(small1x4(), 1,3,8);
            // movePiece(regular1x2(singleFlatPrefab), 1,3.5f,8);

            // //Step 5 (Head)
            // movePiece(singlePiece(neckConnectionPrefab),1,5,-15);
            // movePiece(singlePiece(single2x1Prefab),0,5,-15);
            // movePiece(singlePiece(single2x1Prefab),0,5,-17);
            // //DownBlocks W nose
            // movePiece(piecel3x1(singleSmallBrownPrefab),2,5.5f,-17);
            // movePiece(singlePiece(singlePrefab),2,6.2f,-15);
            // movePiece(singlePiece(singlePrefab),-2,6.2f,-15);
            // movePiece(singlePiece90(noseBasePrefab),0,6.2f,-15);
            // movePiece(noseDotPostion(noseDotPrefab),0,6.2f,-13.6f);
            // //MediumBlocks W eyes
            // movePiece(singlePiece(singlePrefab),2,6.8f,-17);
            // movePiece(singlePiece(singlePrefab),-2,6.8f,-17);
            // movePiece(singlePiece(singlePrefab),0,6.8f,-17);
            // movePiece(singlePiece270(singleWSidePrefab),2,8.2f,-15);
            // movePiece(singlePiece270(singleWSidePrefab),-2,8.2f,-15);
            // movePiece(singlePiece(singlePrefab),0,8.2f,-15);
            // movePiece(singlePiece90(eyePiecePrefab),2,8f,-17);
            // movePiece(singlePiece90(eyePiecePrefab),-2,8f,-17);
            // //TopBlocks
            // movePiece(singlePiece(singlePrefab),2,8.8f,-17);
            // movePiece(singlePiece(singlePrefab),-2,8.8f,-17);
            // movePiece(singlePiece(singlePrefab),0,8.8f,-17);
            // movePiece(piecel3x1(singleSmallBrownPrefab),2,9.5f,-15);
            // //HairBlocks
            // movePiece(regular1x2(singleSmallBrownPrefab),2,10,-15);
            // movePiece(regular1x2(singleSmallBrownPrefab),-2,10,-15);
            // movePiece(singlePiece(halfTrianglePrefab),0,11,-15);
            // movePiece(singlePiece(singleSmallBrownPrefab),0,10,-17);

            // headMovement();

            // -----------------------------------------------
            // *******************HeadStart*******************
            // -----------------------------------------------
            newNeckConnection = Instantiate(neckConnectionPrefab).GetComponentInChildren<SinglePiece>();
            newNeckConnection.Create();
            newNeckConnection.ChangeEnable(false);

            //2x1 Only middle Pieces
            flatMiddle1 = Instantiate(newsingle2x1Prefab).GetComponentInChildren<SinglePiece>();
            flatMiddle1.Create();
            flatMiddle1.ChangeEnable(false);
            flatMiddle2 = Instantiate(newsingle2x1Prefab).GetComponentInChildren<SinglePiece>();
            flatMiddle2.Create();
            flatMiddle2.ChangeEnable(false);

            //BottomPieces
            flat3x1 = Instantiate(small3x1Prefab).GetComponentInChildren<Flat3x1>();
            flat3x1.Create();
            flat3x1.ChangeEnable(false);
            bottomSingle1 = Instantiate(newSinglePrefab).GetComponentInChildren<SinglePiece>();
            bottomSingle1.Create();
            bottomSingle1.ChangeEnable(false);
            bottomNoseConnection = Instantiate(noseBasePrefab).GetComponentInChildren<SinglePiece>();
            bottomNoseConnection.Create();
            bottomNoseConnection.ChangeEnable(false);
            noseDot = Instantiate(noseDotPrefab).GetComponentInChildren<SinglePiece>();
            noseDot.Create();
            noseDot.ChangeEnable(false);
            bottomSingle2 = Instantiate(newSinglePrefab).GetComponentInChildren<SinglePiece>();
            bottomSingle2.Create();
            bottomSingle2.ChangeEnable(false);

            // MiddlePieces
            backMiddleSingle1 = Instantiate(newSinglePrefab).GetComponentInChildren<SinglePiece>();
            backMiddleSingle1.Create();
            backMiddleSingle1.ChangeEnable(false);
            backMiddleSingle2 = Instantiate(newSinglePrefab).GetComponentInChildren<SinglePiece>();
            backMiddleSingle2.Create();
            backMiddleSingle2.ChangeEnable(false);
            backMiddleSingle3 = Instantiate(newSinglePrefab).GetComponentInChildren<SinglePiece>();
            backMiddleSingle3.Create();
            backMiddleSingle3.ChangeEnable(false);

            eyeConnection1 = Instantiate(singleWSidePrefab).GetComponentInChildren<SinglePiece>();
            eyeConnection1.Create();
            eyeConnection1.ChangeEnable(false);
            eyeConnection2 = Instantiate(singleWSidePrefab).GetComponentInChildren<SinglePiece>();
            eyeConnection2.Create();
            eyeConnection2.ChangeEnable(false);
            middleSingle = Instantiate(newSinglePrefab).GetComponentInChildren<SinglePiece>();
            middleSingle.Create();
            middleSingle.ChangeEnable(false);
            eye1 = Instantiate(eyePiecePrefab).GetComponentInChildren<SinglePiece>();
            eye1.Create();
            eye1.ChangeEnable(false);
            eye2 = Instantiate(eyePiecePrefab).GetComponentInChildren<SinglePiece>();
            eye2.Create();
            eye2.ChangeEnable(false);

            // Top1 Pieces
            flat3x1Top = Instantiate(small3x1Prefab).GetComponentInChildren<Flat3x1>();
            flat3x1Top.Create();
            flat3x1Top.ChangeEnable(false);
            topSingle1 = Instantiate(newSinglePrefab).GetComponentInChildren<SinglePiece>();
            topSingle1.Create();
            topSingle1.ChangeEnable(false);
            topSingle2 = Instantiate(newSinglePrefab).GetComponentInChildren<SinglePiece>();
            topSingle2.Create();
            topSingle2.ChangeEnable(false);
            topSingle3 = Instantiate(newSinglePrefab).GetComponentInChildren<SinglePiece>();
            topSingle3.Create();
            topSingle3.ChangeEnable(false);

            // Top2 Pieces
            backTopSmall = Instantiate(newSingleSmallPrefab).GetComponentInChildren<SinglePiece>();
            backTopSmall.Create();
            backTopSmall.ChangeEnable(false);
            flat1x21 = Instantiate(small1x2Prefab).GetComponentInChildren<Flat1x2>();
            flat1x21.Create();
            flat1x21.ChangeEnable(false);
            flat1x22 = Instantiate(small1x2Prefab).GetComponentInChildren<Flat1x2>();
            flat1x22.Create();
            flat1x22.ChangeEnable(false);
            halfTriangle = Instantiate(halfTrianglePrefab).GetComponentInChildren<SinglePiece>();
            halfTriangle.Create();
            halfTriangle.ChangeEnable(false);

            // TailMovement
            tailStart = Instantiate(small3x1Prefab).GetComponentInChildren<Flat3x1>();
            tailStart.Create();
            tailStart.ChangeEnable(false);
            tailNext = Instantiate(flat1x2Prefab).GetComponentInChildren<Flat1x2>();
            tailNext.Create();
            tailNext.ChangeEnable(false);


            // setPiece(headPieces[0].getMesh(), Otter.MatrixOperations.opTranslate(1,5,-15));
            // headPieces[1] = Instantiate(single2x1Prefab).GetComponentInChildren<Otter.BasicLego>();
            // setPiece(headPieces[1].getMesh(), Otter.MatrixOperations.opTranslate(0,5,-15));


            // Pieces.Add(movePiece(regular1x2(singleSmallBrownPrefab),2,10,-15));
            //Add to head and then rotate
            // movePiece(neckConnectionPosition(neckConnectionPrefab),0,2,-15);
                
        }

        // Update is called once per frame
        void Update()
        {
            newNeckConnection.ToOrigin();
            flatMiddle1.ToOrigin();
            flatMiddle2.ToOrigin();

            // newNeckConnection.ChangeEnable(true);
            // flatMiddle1.ChangeEnable(true);
            // flatMiddle2.ChangeEnable(true);
            // newHeadMovement();

            flat3x1.ToOrigin();
            bottomSingle1.ToOrigin();
            bottomNoseConnection.ToOrigin();
            noseDot.ToOrigin();
            bottomSingle2.ToOrigin();

            // flat3x1.ChangeEnable(true);
            // bottomSingle1.ChangeEnable(true);
            // bottomNoseConnection.ChangeEnable(true);
            // noseDot.ChangeEnable(true);
            // bottomSingle2.ChangeEnable(true);
        
            // newHeadMovement2();

            backMiddleSingle1.ToOrigin();
            backMiddleSingle2.ToOrigin();
            backMiddleSingle3.ToOrigin();
            eyeConnection1.ToOrigin();
            eyeConnection2.ToOrigin();
            middleSingle.ToOrigin();
            eye1.ToOrigin();
            eye2.ToOrigin();

            // backMiddleSingle1.ChangeEnable(true);
            // backMiddleSingle2.ChangeEnable(true);
            // backMiddleSingle3.ChangeEnable(true);
            // eyeConnection1.ChangeEnable(true);
            // eyeConnection2.ChangeEnable(true);
            // middleSingle.ChangeEnable(true);
            // eye1.ChangeEnable(true);
            // eye2.ChangeEnable(true);

            // newHeadMovement3();

            flat3x1Top.ToOrigin();
            topSingle1.ToOrigin();
            topSingle2.ToOrigin();
            topSingle3.ToOrigin();

            // flat3x1Top.ChangeEnable(true);
            // topSingle1.ChangeEnable(true);
            // topSingle2.ChangeEnable(true);
            // topSingle3.ChangeEnable(true);

            // newHeadMovement4();

            backTopSmall.ToOrigin();
            flat1x21.ToOrigin();
            flat1x22.ToOrigin();
            halfTriangle.ToOrigin();

            // backTopSmall.ChangeEnable(true);
            // flat1x21.ChangeEnable(true);
            // flat1x22.ChangeEnable(true);
            // halfTriangle.ChangeEnable(true);

            // newHeadMovement5();

            tailStart.ToOrigin();
            tailNext.ToOrigin();

            // newHeadMovement();
                
            // if(Input.GetKeyDown("q")){
                // headAnimation = true;
                // if(headAnimation){
                    // headMovement();
                // }
                
            // } 

            // if(Input.GetKeyDown("right")){
            //     count++;
            // }
            switch(step){
                case 5:
                    newNeckConnection.ChangeEnable(true);
                    flatMiddle1.ChangeEnable(true);
                    flatMiddle2.ChangeEnable(true);
                    newHeadMovement();
                    break;
                case 6:
                    newNeckConnection.ChangeEnable(true);
                    flatMiddle1.ChangeEnable(true);
                    flatMiddle2.ChangeEnable(true);
                    newHeadMovement();

                    flat3x1.ChangeEnable(true);
                    bottomSingle1.ChangeEnable(true);
                    bottomNoseConnection.ChangeEnable(true);
                    noseDot.ChangeEnable(true);
                    bottomSingle2.ChangeEnable(true);
                    newHeadMovement2();
                    break;
                case 7:
                    newNeckConnection.ChangeEnable(true);
                    flatMiddle1.ChangeEnable(true);
                    flatMiddle2.ChangeEnable(true);
                    newHeadMovement();

                    flat3x1.ChangeEnable(true);
                    bottomSingle1.ChangeEnable(true);
                    bottomNoseConnection.ChangeEnable(true);
                    noseDot.ChangeEnable(true);
                    bottomSingle2.ChangeEnable(true);
                    newHeadMovement2();

                    backMiddleSingle1.ChangeEnable(true);
                    backMiddleSingle2.ChangeEnable(true);
                    backMiddleSingle3.ChangeEnable(true);
                    eyeConnection1.ChangeEnable(true);
                    eyeConnection2.ChangeEnable(true);
                    middleSingle.ChangeEnable(true);
                    eye1.ChangeEnable(true);
                    eye2.ChangeEnable(true);
                    newHeadMovement3();
                    break;
                case 8:
                    newNeckConnection.ChangeEnable(true);
                    flatMiddle1.ChangeEnable(true);
                    flatMiddle2.ChangeEnable(true);
                    newHeadMovement();

                    flat3x1.ChangeEnable(true);
                    bottomSingle1.ChangeEnable(true);
                    bottomNoseConnection.ChangeEnable(true);
                    noseDot.ChangeEnable(true);
                    bottomSingle2.ChangeEnable(true);
                    newHeadMovement2();

                    backMiddleSingle1.ChangeEnable(true);
                    backMiddleSingle2.ChangeEnable(true);
                    backMiddleSingle3.ChangeEnable(true);
                    eyeConnection1.ChangeEnable(true);
                    eyeConnection2.ChangeEnable(true);
                    middleSingle.ChangeEnable(true);
                    eye1.ChangeEnable(true);
                    eye2.ChangeEnable(true);
                    newHeadMovement3(); 
                
                    flat3x1Top.ChangeEnable(true);
                    topSingle1.ChangeEnable(true);
                    topSingle2.ChangeEnable(true);
                    topSingle3.ChangeEnable(true);
                    newHeadMovement4();
                    break;
                case 9:
                    newNeckConnection.ChangeEnable(true);
                    flatMiddle1.ChangeEnable(true);
                    flatMiddle2.ChangeEnable(true);
                    newHeadMovement();

                    flat3x1.ChangeEnable(true);
                    bottomSingle1.ChangeEnable(true);
                    bottomNoseConnection.ChangeEnable(true);
                    noseDot.ChangeEnable(true);
                    bottomSingle2.ChangeEnable(true);
                    newHeadMovement2();

                    backMiddleSingle1.ChangeEnable(true);
                    backMiddleSingle2.ChangeEnable(true);
                    backMiddleSingle3.ChangeEnable(true);
                    eyeConnection1.ChangeEnable(true);
                    eyeConnection2.ChangeEnable(true);
                    middleSingle.ChangeEnable(true);
                    eye1.ChangeEnable(true);
                    eye2.ChangeEnable(true);
                    newHeadMovement3(); 
                
                    flat3x1Top.ChangeEnable(true);
                    topSingle1.ChangeEnable(true);
                    topSingle2.ChangeEnable(true);
                    topSingle3.ChangeEnable(true);
                    newHeadMovement4();

                    backTopSmall.ChangeEnable(true);
                    flat1x21.ChangeEnable(true);
                    flat1x22.ChangeEnable(true);
                    halfTriangle.ChangeEnable(true);
                    newHeadMovement5();
                    break;
                case 10:
                    newNeckConnection.ChangeEnable(true);
                    flatMiddle1.ChangeEnable(true);
                    flatMiddle2.ChangeEnable(true);
                    newHeadMovement();

                    flat3x1.ChangeEnable(true);
                    bottomSingle1.ChangeEnable(true);
                    bottomNoseConnection.ChangeEnable(true);
                    noseDot.ChangeEnable(true);
                    bottomSingle2.ChangeEnable(true);
                    newHeadMovement2();

                    backMiddleSingle1.ChangeEnable(true);
                    backMiddleSingle2.ChangeEnable(true);
                    backMiddleSingle3.ChangeEnable(true);
                    eyeConnection1.ChangeEnable(true);
                    eyeConnection2.ChangeEnable(true);
                    middleSingle.ChangeEnable(true);
                    eye1.ChangeEnable(true);
                    eye2.ChangeEnable(true);
                    newHeadMovement3(); 
                
                    flat3x1Top.ChangeEnable(true);
                    topSingle1.ChangeEnable(true);
                    topSingle2.ChangeEnable(true);
                    topSingle3.ChangeEnable(true);
                    newHeadMovement4();

                    backTopSmall.ChangeEnable(true);
                    flat1x21.ChangeEnable(true);
                    flat1x22.ChangeEnable(true);
                    halfTriangle.ChangeEnable(true);
                    newHeadMovement5();

                    tailStart.ChangeEnable(true);
                    tailNext.ChangeEnable(true);
                    newTailMovement();

                    animate = true;
                    particleSystem.StartParticle();
                    break;
                default:
                    break;
            }

        
        
            if(Input.GetKeyDown("right")){
                if (step < 10)
                {
                    step++;
                }
                
                print("Step "+step);
                switch(step){
                case 1:
                    small2x8();
                    break;
                case 2:
                    //RightSide
                    movePiece(doubleDiagonal(), 0,1.3f,-2);
                    movePiece(doubleDiagonal(), 0,1.3f,-6);
                    movePiece(doubleDiagonal(), 0,1.3f,-10);
                    //LeftSide
                    movePiece(doubleDiagonal180(), 2,1.3f,-2);
                    movePiece(doubleDiagonal180(), 2,1.3f,-6);
                    movePiece(doubleDiagonal180(), 2,1.3f,-10);
                    //Tail
                    movePiece(doubleDiagonal90(), 2,1.3f,0);
                    break;
                case 3:
                    movePiece(small2x1(), 0,2.5f,-12);
                    movePiece(small2x1(), 4,2.5f,-12);

                    movePiece(regular1x2(singlePrefab), -2,3.2f,-8);
                    movePiece(regular1x2(singlePrefab), 4,3.2f,-8);

                    movePiece(small1x4(), -2,2.5f,0);
                    movePiece(small1x4(), 4,2.5f,0);
                    //BeigeCenter
                    movePiece(small2x4(singleSmallBeigePrefab), 0,2.5f,-4);
                    break;
                case 4:
                    //Step4
                    movePiece(singlePiece(circleSmallPrefab),3.5f,4.5f,-11.2f);
                    movePiece(singlePiece(circleSmallPrefab),-1f,4.5f,-11.2f);
                
                    movePiece(singlePiece90(diagonalPrefab),4,3.8f,0);
                    movePiece(singlePiece90(diagonalPrefab),-2,3.8f,0);

                    //NeckBase
                    movePiece(singlePiece180(neckBasePrefab),1,1.3f,-14);

                    //Tail
                    movePiece(singlePiece(single2x1Prefab), 1,2.6f,2);
                    // movePiece(small1x4(), 1,3,8);
                    // movePiece(regular1x2(singleFlatPrefab), 1,3.5f,8);
                    break;
                case 5:
                    // //Step 5 (Head)
                    // movePiece(singlePiece(neckConnectionPrefab),1,5,-15);
                    // movePiece(singlePiece(single2x1Prefab),0,5,-15);
                    // movePiece(singlePiece(single2x1Prefab),0,5,-17);
                    // //DownBlocks W nose
                    // movePiece(piecel3x1(singleSmallBrownPrefab),2,5.5f,-17);
                    // movePiece(singlePiece(singlePrefab),2,6.2f,-15);
                    // movePiece(singlePiece(singlePrefab),-2,6.2f,-15);
                    // movePiece(singlePiece90(noseBasePrefab),0,6.2f,-15);
                    // movePiece(noseDotPostion(noseDotPrefab),0,6.2f,-13.6f);
                    // //MediumBlocks W eyes
                    // movePiece(singlePiece(singlePrefab),2,6.8f,-17);
                    // movePiece(singlePiece(singlePrefab),-2,6.8f,-17);
                    // movePiece(singlePiece(singlePrefab),0,6.8f,-17);
                    // movePiece(singlePiece270(singleWSidePrefab),2,8.2f,-15);
                    // movePiece(singlePiece270(singleWSidePrefab),-2,8.2f,-15);
                    // movePiece(singlePiece(singlePrefab),0,8.2f,-15);
                    // movePiece(singlePiece90(eyePiecePrefab),2,8f,-17);
                    // movePiece(singlePiece90(eyePiecePrefab),-2,8f,-17);
                    // //TopBlocks
                    // movePiece(singlePiece(singlePrefab),2,8.8f,-17);
                    // movePiece(singlePiece(singlePrefab),-2,8.8f,-17);
                    // movePiece(singlePiece(singlePrefab),0,8.8f,-17);
                    // movePiece(piecel3x1(singleSmallBrownPrefab),2,9.5f,-15);
                    // //HairBlocks
                    // movePiece(regular1x2(singleSmallBrownPrefab),2,10,-15);
                    // movePiece(regular1x2(singleSmallBrownPrefab),-2,10,-15);
                    // movePiece(singlePiece(halfTrianglePrefab),0,11,-15);
                    // movePiece(singlePiece(singleSmallBrownPrefab),0,10,-17);

                    //NewStep5
                    // newNeckConnection.ChangeEnable(true);
                    // newHeadMovement();
                    break;
                default:
                    print ("Incorrect step.");
                break;

            }
            
            }
        
        }

        //Para el movimiento se neceista guardar la matrix4x4 del ancla (NeckConnection)
        //A partir dre estan,s er[a el nuevo punto de inicio para las nuevas ppiezas que se mueven con la misma, o sea, la cabeza completa

        // void headMovement(){
        
         

        //     Matrix4x4 rotX = Otter.MatrixOperations.opRotate(connectorRot, Otter.MatrixOperations.AXIS.AX_X);
        //     // Matrix4x4 right = Otter.MatrixOperations.opTranslate(1,5,-15);
        //     // Matrix4x4 scale = Otter.MatrixOperations.opScale(1, 0.5f, 0.5f);

        //     // Matrix4x4 transformNoScale = rotX * right;
        //     Matrix4x4 transformNoScale = rotX ;
        //     setPiece(headPieces[0].getMesh(), transformNoScale);
        //     setPiece(headPieces[1].getMesh(), transformNoScale);

        //     // translateConnector = Otter.MatrixOperations.opTranslate(-4.34f, 6f, 3f);
        //     // movePiece(singlePiece(neckConnectionPrefab),1,5,-15);

        // }

        void newHeadMovement(){

            if(animate == true)
            {
                neckRot += neckDir * 0.4f;
            }
            
            if(neckRot <= -5f || neckRot > 5f){
                neckDir =-neckDir;
            }

            translateNeckConnection = Otter.MatrixOperations.opTranslate(1.9f,2.5f,-14.7f);
            Matrix4x4 rotConnector = Otter.MatrixOperations.opRotate(neckRot, Otter.MatrixOperations.AXIS.AX_X);
            Matrix4x4 rotConnectorY = Otter.MatrixOperations.opRotate(-45, Otter.MatrixOperations.AXIS.AX_X);
            transformNeckConnection = translateNeckConnection * rotConnector * rotConnectorY;
            newNeckConnection.UpdateMeshes(transformNeckConnection);

            Matrix4x4 translateSingle1 = Otter.MatrixOperations.opTranslate(-1,0.1f,0);
            Matrix4x4 transform1 = transformNeckConnection * translateSingle1;
            flatMiddle1.UpdateMeshes(transform1);

            Matrix4x4 translateSingle2 = Otter.MatrixOperations.opTranslate(-1,0.1f,-2);
            Matrix4x4 transform2 = transformNeckConnection * translateSingle2;
            flatMiddle2.UpdateMeshes(transform2);

        }

        void newHeadMovement2(){
            Matrix4x4 translateFlat = Otter.MatrixOperations.opTranslate(1,0.6f,-2);
            Matrix4x4 transformFlat = transformNeckConnection * translateFlat;
            flat3x1.UpdateMeshes(transformFlat);

            Matrix4x4 translateSingle1 = Otter.MatrixOperations.opTranslate(-3,1.3f,0);
            Matrix4x4 transformSingle1 = transformNeckConnection * translateSingle1;
            bottomSingle1.UpdateMeshes(transformSingle1);

            Matrix4x4 translateNoseBase = Otter.MatrixOperations.opTranslate(-1,1.3f,0);
            Matrix4x4 rotY = Otter.MatrixOperations.opRotate(90, Otter.MatrixOperations.AXIS.AX_Y);
            Matrix4x4 transformNoseBase = transformNeckConnection * translateNoseBase * rotY;
            bottomNoseConnection.UpdateMeshes(transformNoseBase);

            Matrix4x4 translateNoseDot = Otter.MatrixOperations.opTranslate(-1,1.3f,1.5f);
            Matrix4x4 rotX = Otter.MatrixOperations.opRotate(90, Otter.MatrixOperations.AXIS.AX_X);
            Matrix4x4 transformNoseDot = transformNeckConnection * translateNoseDot * rotX;
            noseDot.UpdateMeshes(transformNoseDot);

            Matrix4x4 translateSingle2 = Otter.MatrixOperations.opTranslate(1,1.3f,0);
            Matrix4x4 transformSingle2 = transformNeckConnection * translateSingle2;
            bottomSingle2.UpdateMeshes(transformSingle2);

        }

        void newHeadMovement3(){
            Matrix4x4 translateBack1 = Otter.MatrixOperations.opTranslate(1,1.9f,-2);
            Matrix4x4 transformBack1 = transformNeckConnection * translateBack1;
            backMiddleSingle1.UpdateMeshes(transformBack1);

            Matrix4x4 translateBack2 = Otter.MatrixOperations.opTranslate(-1,1.9f,-2);
            Matrix4x4 transformBack2 = transformNeckConnection * translateBack2;
            backMiddleSingle2.UpdateMeshes(transformBack2);

            Matrix4x4 translateBack3 = Otter.MatrixOperations.opTranslate(-3,1.9f,-2);
            Matrix4x4 transformBack3 = transformNeckConnection * translateBack3;
            backMiddleSingle3.UpdateMeshes(transformBack3);

            Matrix4x4 translateMiddleSingle = Otter.MatrixOperations.opTranslate(-1,3.3f,0);
            Matrix4x4 transformMiddleSingle = transformNeckConnection * translateMiddleSingle;
            middleSingle.UpdateMeshes(transformMiddleSingle);

            Matrix4x4 rotEyeBase = Otter.MatrixOperations.opRotate(270, Otter.MatrixOperations.AXIS.AX_Y);

            Matrix4x4 translateEyeBase1 = Otter.MatrixOperations.opTranslate(1,3.3f,0);
            Matrix4x4 transformEyeBase1 = transformNeckConnection * translateEyeBase1 * rotEyeBase;
            eyeConnection1.UpdateMeshes(transformEyeBase1);

            Matrix4x4 translateEyeBase2 = Otter.MatrixOperations.opTranslate(-3,3.3f,0);
            Matrix4x4 transformEyeBase2 = transformNeckConnection * translateEyeBase2 * rotEyeBase;
            eyeConnection2.UpdateMeshes(transformEyeBase2);

            Matrix4x4 rotEye = Otter.MatrixOperations.opRotate(90, Otter.MatrixOperations.AXIS.AX_Y);

            Matrix4x4 translateEye1 = Otter.MatrixOperations.opTranslate(1,3.1f,-2);
            Matrix4x4 transformEye1 = transformNeckConnection * translateEye1 * rotEye;
            eye1.UpdateMeshes(transformEye1);

            Matrix4x4 translateEye2 = Otter.MatrixOperations.opTranslate(-3,3.1f,-2);
            Matrix4x4 transformEye2 = transformNeckConnection * translateEye2 * rotEye;
            eye2.UpdateMeshes(transformEye2);
        }

        void newHeadMovement4(){
            Matrix4x4 translateFlat = Otter.MatrixOperations.opTranslate(1,4.6f,0);
            Matrix4x4 transformFlat = transformNeckConnection * translateFlat;
            flat3x1Top.UpdateMeshes(transformFlat);

            Matrix4x4 translateSingle1 = Otter.MatrixOperations.opTranslate(-3,3.9f,-2);
            Matrix4x4 transformSingle1 = transformNeckConnection * translateSingle1;
            topSingle1.UpdateMeshes(transformSingle1);

            Matrix4x4 translateSingle2 = Otter.MatrixOperations.opTranslate(-1,3.9f,-2);
            Matrix4x4 transformSingle2 = transformNeckConnection * translateSingle2;
            topSingle2.UpdateMeshes(transformSingle2);

            Matrix4x4 translateSingle3 = Otter.MatrixOperations.opTranslate(1,3.9f,-2);
            Matrix4x4 transformSingle3 = transformNeckConnection * translateSingle3;
            topSingle3.UpdateMeshes(transformSingle3);
        }
    
        void newHeadMovement5(){
            Matrix4x4 translateSingle1 = Otter.MatrixOperations.opTranslate(-1,5f,-2);
            Matrix4x4 transformSingle1 = transformNeckConnection * translateSingle1;
            backTopSmall.UpdateMeshes(transformSingle1); 

            Matrix4x4 translateHalfTriangle = Otter.MatrixOperations.opTranslate(-1,5.9f,0);
            Matrix4x4 transformHalfTriangle = transformNeckConnection * translateHalfTriangle;
            halfTriangle.UpdateMeshes(transformHalfTriangle); 

            Matrix4x4 translateSmall2x11 = Otter.MatrixOperations.opTranslate(-3,5f,0);
            Matrix4x4 transformSmall2x11 = transformNeckConnection * translateSmall2x11;
            flat1x21.UpdateMeshes(transformSmall2x11); 

            Matrix4x4 translateSmall2x12 = Otter.MatrixOperations.opTranslate(1,5f,0);
            Matrix4x4 transformSmall2x12 = transformNeckConnection * translateSmall2x12;
            flat1x22.UpdateMeshes(transformSmall2x12); 
        }

        void newTailMovement(){
            if(animate == true)
            {
                tailRot += tailDir * 0.4f;
            }
            
            if(tailRot <= -5f || tailRot > 5f){
                tailDir =- tailDir;
            }

            translateTailConnection = Otter.MatrixOperations.opTranslate(1,3.15f,2);
            Matrix4x4 rotTailStart = Otter.MatrixOperations.opRotate(90, Otter.MatrixOperations.AXIS.AX_Y);
            Matrix4x4 rotConnector = Otter.MatrixOperations.opRotate(tailRot, Otter.MatrixOperations.AXIS.AX_Y);
            // Matrix4x4 rotConnectorY = Otter.MatrixOperations.opRotate(-45, Otter.MatrixOperations.AXIS.AX_X);
            transformTailConnection = translateTailConnection * rotConnector * rotTailStart;
            tailStart.UpdateMeshes(transformTailConnection);

            // Matrix4x4 translateTailStart = Otter.MatrixOperations.opTranslate(-1,5f,-2);
            // Matrix4x4 transformTailStart = transformNeckConnection * translateTailStart;
            // tailStart.UpdateMeshes(transformTailStart); 

            Matrix4x4 translateTailNext = Otter.MatrixOperations.opTranslate(-4,0.6f,0);
            Matrix4x4 transformTailNext = transformTailConnection * translateTailNext * rotTailStart;
            tailNext.UpdateMeshes(transformTailNext);
        }

        void setPiece(Mesh m, Matrix4x4 tm){
            Vector3[] points = m.vertices;
            int total = points.Length;
            for(int i=0; i<total; i++){
                Vector4 v  = new Vector4(points[i].x, points[i].y, points[i].z, 1);
                v = tm*v;
                points[i] = new Vector3(v.x, v.y, v.z);
            }   
            m.vertices = points;
            m.RecalculateNormals();
        }

        void movePiece(Otter.BasicLego[] piece, float tx, float ty, float tz){
            foreach(Otter.BasicLego brick in piece){
                setPiece(brick.getMesh(), Otter.MatrixOperations.opTranslate(tx, ty, tz));
            }
        }   

        // Otter.BasicLego newMovePiece(Otter.BasicLego piece, float tx, float ty, float tz){
        //     foreach(Otter.BasicLego brick in piece){
        //         setPiece(brick.getMesh(), Otter.MatrixOperations.opTranslate(tx, ty, tz));
        //     }
        // } 

        Otter.BasicLego[] singlePiece(GameObject piece){
            Otter.BasicLego[] brick = new Otter.BasicLego[1];
            brick[0] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();

            return brick;
        }
         Otter.BasicLego[] singlePiece90(GameObject piece){
            Otter.BasicLego[] brick = new Otter.BasicLego[1];

            brick[0] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[0].getMesh(), Otter.MatrixOperations.opRotate(90, Otter.MatrixOperations.AXIS.AX_Y));
            return brick;
        }
        Otter.BasicLego[] singlePiece180(GameObject piece){
            Otter.BasicLego[] brick = new Otter.BasicLego[1];

            brick[0] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[0].getMesh(), Otter.MatrixOperations.opRotate(180, Otter.MatrixOperations.AXIS.AX_Y));
            return brick;
        }
        Otter.BasicLego[] singlePiece270(GameObject piece){
            Otter.BasicLego[] brick = new Otter.BasicLego[1];

            brick[0] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[0].getMesh(), Otter.MatrixOperations.opRotate(270, Otter.MatrixOperations.AXIS.AX_Y));
            return brick;
        }
        Otter.BasicLego[] noseDotPostion(GameObject piece){
            Otter.BasicLego[] brick = new Otter.BasicLego[1];

            brick[0] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[0].getMesh(), Otter.MatrixOperations.opRotate(90, Otter.MatrixOperations.AXIS.AX_X));
            return brick;
        }

        // Otter.BasicLego[] neckConnectionPosition(GameObject piece){
        //     Otter.BasicLego[] brick = new Otter.BasicLego[1];

        //     brick[0] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();

        //     setPiece(brick[0].getMesh(), Otter.MatrixOperations.opRotate(180, Otter.MatrixOperations.AXIS.AX_Y));
        //     setPiece(brick[0].getMesh(), Otter.MatrixOperations.opRotate(-45, Otter.MatrixOperations.AXIS.AX_X));
        //     return brick;
        // }


        //Not needed
        void brick2x2(){
            Otter.BasicLego[] brick = new Otter.BasicLego[4];

            brick[0] = Instantiate(singlePrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[1] = Instantiate(singlePrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[2] = Instantiate(singlePrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[3] = Instantiate(singlePrefab).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[1].getMesh(), Otter.MatrixOperations.opTranslate(2,0,0));
            setPiece(brick[2].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-2));
            setPiece(brick[3].getMesh(), Otter.MatrixOperations.opTranslate(2,0,-2));
        }

        Otter.BasicLego[] regular1x2(GameObject piece){
            Otter.BasicLego[] brick = new Otter.BasicLego[2];

            brick[0] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();
            brick[1] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();

            setPiece (brick[1].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-2));

            // Pieces.Add(brick);
            return brick;
        }

        Otter.BasicLego[] small2x1(){
            Otter.BasicLego[] brick = new Otter.BasicLego[2];

            brick[0] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[1] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[1].getMesh(), Otter.MatrixOperations.opTranslate(-2,0,0));

            return brick;
        }

        Otter.BasicLego[] small2x8(){
            Otter.BasicLego[] brick = new Otter.BasicLego[16];

            brick[0] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[1] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[2] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[3] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[4] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[5] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[6] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[7] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[8] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[9] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[10] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[11] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[12] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[13] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[14] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[15] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[1].getMesh(), right);

            setPiece(brick[2].getMesh(), down);
            setPiece(brick[3].getMesh(), right);
            setPiece(brick[3].getMesh(), down);

            setPiece(brick[4].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-4));
            setPiece(brick[5].getMesh(), Otter.MatrixOperations.opTranslate(2,0,-4));

            setPiece(brick[6].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-6));
            setPiece(brick[7].getMesh(), Otter.MatrixOperations.opTranslate(2,0,-6));

            setPiece(brick[8].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-8));
            setPiece(brick[9].getMesh(), Otter.MatrixOperations.opTranslate(2,0,-8));

            setPiece(brick[10].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-10));
            setPiece(brick[11].getMesh(), Otter.MatrixOperations.opTranslate(2,0,-10));

            setPiece(brick[12].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-12));
            setPiece(brick[13].getMesh(), Otter.MatrixOperations.opTranslate(2,0,-12));
        
            setPiece(brick[14].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-14));
            setPiece(brick[15].getMesh(), Otter.MatrixOperations.opTranslate(2,0,-14));

            return brick;
        }

        Otter.BasicLego[] piecel3x1(GameObject piece){
            Otter.BasicLego[] brick = new Otter.BasicLego[3];

            brick[0] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();
            brick[1] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();
            brick[2] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[1].getMesh(), Otter.MatrixOperations.opTranslate(-2,0,0));
            setPiece(brick[2].getMesh(), Otter.MatrixOperations.opTranslate(-4,0,0));

            return brick;
        }

        Otter.BasicLego[] small1x4(){
            Otter.BasicLego[] brick = new Otter.BasicLego[4];

            brick[0] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[1] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[2] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[3] = Instantiate(singleSmallBrownPrefab).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[1].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-2));
            setPiece(brick[2].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-4));
            setPiece(brick[3].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-6));

            return brick;
        }

        Otter.BasicLego[] small2x4(GameObject piece){
            Otter.BasicLego[] brick = new Otter.BasicLego[8];

            brick[0] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();
            brick[1] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();
            brick[2] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();
            brick[3] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();
            brick[4] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();
            brick[5] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();
            brick[6] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();
            brick[7] = Instantiate(piece).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[1].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-2));
            setPiece(brick[2].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-4));
            setPiece(brick[3].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-6));
        
            setPiece(brick[4].getMesh(), Otter.MatrixOperations.opTranslate(2,0,0));
            setPiece(brick[5].getMesh(), Otter.MatrixOperations.opTranslate(2,0,-2));
            setPiece(brick[6].getMesh(), Otter.MatrixOperations.opTranslate(2,0,-4));
            setPiece(brick[7].getMesh(), Otter.MatrixOperations.opTranslate(2,0,-6));

            return brick;
        }

        Otter.BasicLego[] doubleDiagonal(){
            Otter.BasicLego[] brick = new Otter.BasicLego[2];

            brick[0] = Instantiate(diagonalPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[1] = Instantiate(diagonalPrefab).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[1].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-2));

            return brick;
        }

        Otter.BasicLego[] doubleDiagonal180(){
            Otter.BasicLego[] brick = new Otter.BasicLego[2];

            brick[0] = Instantiate(diagonalPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[1] = Instantiate(diagonalPrefab).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[0].getMesh(), Otter.MatrixOperations.opRotate(180, Otter.MatrixOperations.AXIS.AX_Y));
            setPiece(brick[1].getMesh(), Otter.MatrixOperations.opRotate(180, Otter.MatrixOperations.AXIS.AX_Y));
            setPiece(brick[1].getMesh(), Otter.MatrixOperations.opTranslate(0,0,-2));

            return brick;
        }
        Otter.BasicLego[] doubleDiagonal90(){
            Otter.BasicLego[] brick = new Otter.BasicLego[2];

            brick[0] = Instantiate(diagonalPrefab).GetComponentInChildren<Otter.BasicLego>();
            brick[1] = Instantiate(diagonalPrefab).GetComponentInChildren<Otter.BasicLego>();

            setPiece(brick[0].getMesh(), Otter.MatrixOperations.opRotate(90, Otter.MatrixOperations.AXIS.AX_Y));
            setPiece(brick[1].getMesh(), Otter.MatrixOperations.opRotate(90, Otter.MatrixOperations.AXIS.AX_Y));
            setPiece(brick[1].getMesh(), Otter.MatrixOperations.opTranslate(-2,0,0));

            return brick;
        }

    }
}