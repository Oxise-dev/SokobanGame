
namespace SocobanGame.FSM
{
	abstract class BaseState : IState
	{
		public StateMachine StateMachine { get; }
		public BaseState(StateMachine stateMachine) => StateMachine = stateMachine;
		public abstract void Update(float deltaTime);
		public abstract void Draw();
		public abstract void Enter();
		public abstract void Exit();
	}
}
