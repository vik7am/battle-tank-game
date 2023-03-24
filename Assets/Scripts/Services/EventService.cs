using System;

namespace BattleTank
{
    public class EventService : GenericSingleton<EventService>
    {
        public event Action<TankName> OnBulletFired;
        public event Action<TankName, TankName> OnTankDestroyed;
        public event Action<TankName, TankName> OnBulletHit;

        public void BulletFired(TankName tankName){
            OnBulletFired?.Invoke(tankName);
        }

        public void TankDestroyed(TankName shooter, TankName reciever){
            OnTankDestroyed?.Invoke(shooter, reciever);
        }

        public void BulletHit(TankName shooter, TankName reciever){
            OnBulletHit?.Invoke(shooter, reciever);
        }
    }
}
