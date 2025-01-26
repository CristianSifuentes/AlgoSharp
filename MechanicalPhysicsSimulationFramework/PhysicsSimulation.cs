// Class for managing multiple physical objects
public class PhysicsSimulation<T> where T : IPhysicsEntity {
   
   private readonly List<T> _entities = new();
   public void AddEntity(T entity) => _entities.Add(entity);
   public void UpdateAll(double timeStep){
      foreach(var entity in _entities){
        entity.Update(timeStep);
      }
   }

   public IEnumerable<T> GetEntities(){
      foreach(var entity in _entities){
        yield return entity;
      }
   }
}