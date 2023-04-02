using UnityEngine;

namespace BattleTank
{
    public class CameraService : GenericMonoSingleton<CameraService>
    {
        [SerializeField] private Camera cam;
        private bool camZoomOut;
        [SerializeField] private float camSize;

        private void Start() {
            DestructionService.onDestructionStart += StartCameraZoomOut;
            DestructionService.onDestructionEnd += StopCameraZoomOut;
            PlayerTankController.onTankDestroyed += StopFollowingPlayer;
            camZoomOut = false;
        }

        public void StartFollowingPlayer(Transform player){
            transform.position = player.position;
            transform.SetParent(player);
        }

        public void StopFollowingPlayer(TankId tankId){
            transform.SetParent(null);
        }

        public void StartCameraZoomOut(){
            camZoomOut = true;
        }

        public void StopCameraZoomOut(){
            camZoomOut = true;
        }

        private void Update() {
            if(camZoomOut){
                camSize += 1.0f * Time.deltaTime;
                cam.orthographicSize = camSize;
            }
        }
    }
}
