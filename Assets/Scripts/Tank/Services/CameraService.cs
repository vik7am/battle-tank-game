using UnityEngine;

namespace BattleTank
{
    public class CameraService : GenericSingleton<CameraService>
    {
        [SerializeField] private Camera cam;
        private bool camZoomOut;
        private float camSize;

        private void Start() {
            camZoomOut = false;
            camSize = 15;
        }

        public void StartFollowingPlayer(Transform player){
            transform.position = player.position;
            transform.SetParent(player);
        }

        public void StopFollowingPlayer(){
            transform.SetParent(null);
        }

        public void SetCameraZoomOut(bool status){
            camZoomOut = status;
        }

        private void Update() {
            if(camZoomOut){
                camSize += 1.0f * Time.deltaTime;
                cam.orthographicSize = camSize;
            }
        }
    }
}
