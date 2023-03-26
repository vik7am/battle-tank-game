using System;

namespace BattleTank
{
    public class EventService : GenericSingleton<EventService>
    {
        public event Action<TankName> onBulletFired;
        public event Action<TankName, TankName> onTankDestroyed;
        public event Action<TankName, TankName> onBulletHit;

        public void OnBulletFired(TankName tankName){
            onBulletFired?.Invoke(tankName);
        }

        public void OnTankDestroyed(TankName shooter, TankName reciever){
            onTankDestroyed?.Invoke(shooter, reciever);
        }

        public void OnBulletHit(TankName shooter, TankName reciever){
            onBulletHit?.Invoke(shooter, reciever);
        }
    }
}
