using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks; //  API 호출과 영상 출력은 서로 독립적인 작업이며, 이를 동시에 처리하려면 다른 스레드를 사용해야 하기 때문
using System.Windows.Forms;


namespace project2
{
    public partial class faceid : Form
    {
        private readonly string accessKey = "AKIAX3DNHQBTMNATIUXZ"; // AWS Access Key
        private readonly string secretKey = "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"; // AWS Secret Key
        private readonly string region = "ap-northeast-2"; // 사용할 AWS 리전

        private readonly AmazonRekognitionClient rekognitionClient;
        private VideoCapture capture;
        private bool isCameraRunning = false;


        public faceid()
        {
            InitializeComponent();
            rekognitionClient = new AmazonRekognitionClient(new BasicAWSCredentials(accessKey, secretKey), Amazon.RegionEndpoint.APNortheast2);
            capture = new VideoCapture(0); // 기본 카메라 장치 열기
            this.FormClosed += new FormClosedEventHandler(faceid_FormClosed);
        }

        private void StartCamera()
        {
            if (!capture.IsOpened())
            {
                MessageBox.Show("카메라를 열 수 없습니다.");
                return;
            }

            isCameraRunning = true;

            // 카메라 영상을 UI 스레드에서 업데이트하기 위해 Invoke 사용
            Task.Run(() =>
            {
                while (isCameraRunning)
                {
                    using (var frame = new Mat())
                    {
                        capture.Read(frame); // 프레임 읽기
                        if (frame.Empty())
                        {
                            continue; // 빈 프레임은 넘기기
                        }

                        var bitmap = BitmapConverter.ToBitmap(frame); // 프레임을 Bitmap으로 변환

                        // 폼이 닫혔거나 카메라 중지 상태라면 반복문 종료
                        if (this.IsDisposed || !isCameraRunning)
                        {
                            return; // 비동기 작업 종료
                        }

                        // UI 스레드에서 pictureBox1 업데이트
                        if (this.InvokeRequired)
                        {
                            this.Invoke((Action)(() =>
                            {
                                pictureBox1.Image?.Dispose(); // 이전 이미지 해제
                                pictureBox1.Image = bitmap; // 새로운 이미지 설정
                            }));
                        }
                        else
                        {
                            pictureBox1.Image?.Dispose(); // 이전 이미지 해제
                            pictureBox1.Image = bitmap; // 새로운 이미지 설정
                        }
                    }
                }
            });
        }


        private void faceid_Load(object sender, EventArgs e)
        {
            StartCamera(); // 폼이 로드되면 자동으로 카메라 시작
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // 여러 저장된 사진들의 경로 리스트
            string[] sourceImagePaths = new string[]
            {
        @"C:\Users\mo\source\repos\Project2\bin\Debug\net8.0-windows7.0\Images\lty.jpg",
        @"C:\Users\mo\source\repos\Project2\bin\Debug\net8.0-windows7.0\Images\ljm.jpg",
        @"C:\Users\mo\source\repos\Project2\bin\Debug\net8.0-windows7.0\Images\face_20241106_154808.jpg",
            };

            try
            {
                // 현재 PictureBox에 표시된 프레임을 가져오기
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("캡처된 이미지가 없습니다.");
                    return;
                }

                // PictureBox 이미지를 바이트 배열로 변환
                var targetImageBytes = (byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[]));

                bool isMatch = false;
                float highestSimilarity = 0f;

                // 각 저장된 사진에 대해 얼굴 비교 수행
                foreach (var sourceImagePath in sourceImagePaths)
                {
                    // 저장된 사진을 바이트 배열로 읽기
                    var sourceImageBytes = File.ReadAllBytes(sourceImagePath);

                    // Amazon Rekognition Model의 Image를 명시적으로 지정
                    var compareFacesRequest = new CompareFacesRequest
                    {
                        SourceImage = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(sourceImageBytes) },
                        TargetImage = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(targetImageBytes) },
                        SimilarityThreshold = 90f
                    };

                    var compareFacesResponse = await rekognitionClient.CompareFacesAsync(compareFacesRequest);

                    // 얼굴 일치율 확인
                    foreach (var faceMatch in compareFacesResponse.FaceMatches)
                    {
                        if (faceMatch.Similarity.HasValue && faceMatch.Similarity.Value >= 90)
                        {
                            isMatch = true;
                            highestSimilarity = faceMatch.Similarity.Value;
                            break;
                        }
                    }

                    // 일치하는 얼굴이 있을 경우 종료
                    if (isMatch)
                    {

                        // 일치율이 90% 이상이면 menu 폼을 띄움
                        if (highestSimilarity >= 90f)
                        {
                            // menu 폼을 열기
                            menu menuForm = new menu();  // menu 폼을 인스턴스화
                            menuForm.Show();  // 폼을 띄움
                            this.Hide();
                        }

                        return;
                    }
                }

                // 일치하지 않으면 출력
                if (!isMatch)
                {
                    label1.Text = "일치하지 않습니다";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 발생: {ex.Message}");
            }
        }


        private void faceid_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 카메라가 열려 있을 때만 중지
            if (capture.IsOpened())
            {
                isCameraRunning = false; // 카메라 중지
                capture.Release(); // 카메라 자원 해제
            }

            // pictureBox1에 이미지가 있을 경우만 Dispose 호출
            pictureBox1.Image?.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 먼저 login 폼을 열고
            login loginForm = new login();
            loginForm.Show();

            // 그 후에 현재 폼을 닫습니다
            this.Hide();
        }
    }
}
