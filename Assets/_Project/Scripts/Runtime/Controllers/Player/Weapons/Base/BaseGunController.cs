using _Project.Runtime.Controllers.Physics;
using _Project.Runtime.Controllers.Weapons.Models;
using UnityEngine;

namespace _Project.Runtime.Controllers.Weapons
{
    public abstract class BaseGunController<TModel> : IGunController where TModel : BaseWeaponModel
    {
        public IWeaponModel WeaponModel => Model;
        
        protected readonly TModel Model;
        
        protected BaseGunController(TModel model)
        {
            Model = model;
        }

        public void Shoot()
        {
            if (!Model.CanShoot()) return;
            ShootInternal();
            Model.Shoot();
        }

        public virtual void ResetState()
        {
            Model.Reset();
        }

        protected abstract void ShootInternal();

        public virtual void Update(float deltaTime)
        {
            Model.Update(deltaTime);
        }

        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}