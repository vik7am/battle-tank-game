using UnityEngine;

namespace BattleTank
{
    public class CameraService : GenericMonoSingleton<CameraService>
    {
        private bool camZoomOut;
        [SerializeField] private Camera cam;
        [SerializeField] private float camZoomOutSpeed;
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
                camSize += camZoomOutSpeed * Time.deltaTime;
                cam.orthographicSize = camSize;
            }
        }
    }
}
