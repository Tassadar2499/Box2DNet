using Box2DNet.CommonCopy.ExtensionMethods;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

using _Consts = Box2DNet.CommonCopy.Consts.Consts;

namespace Box2DNet.CommonCopy
{
	/// <summary>
	/// Сущность Размах - описывает движение тела / фигуры для вычисления TOI.
	/// Формы определяются относительно происхождения тела, которое может не совпадать с центром масс.
	/// Однако, чтобы поддержать динамику, мы должны интерполировать положение центра масс.
	/// </summary>
	public struct Sweep
	{
		/// <summary>
		/// Локальная позиция центра масс
		/// </summary>
		public Vector2f LocalCenter;
		/// <summary>
		/// Центры масс относительно мира
		/// </summary>
		public Vector2f MassCenterZero, MassCenter;
		/// <summary>
		/// Углы мира
		/// </summary>
		public float AngleZero, Angle;
		/// <summary>
		/// Временной интервал = [T0,1], где T0 в промежутке [0,1]
		/// </summary>
		public float TimeInterval;

		public Sweep(Vector2f localCenter, Vector2f massCenterZero, Vector2f massCenter, float angleZero, float angle, float timeInterval)
		{
			if (timeInterval < 0 || timeInterval > 1)
				throw new ArgumentException($"{nameof(timeInterval)} is less than zero or greater than 1");
			TimeInterval = timeInterval;

			LocalCenter = localCenter;
			MassCenterZero = massCenterZero;
			MassCenter = massCenter;
			AngleZero = angleZero;
			Angle = angle;
		}

		/// <summary>
		/// Получите интерполированную трансформацию в определенный момент времени
		/// </summary>
		/// <param name="alpha">угол в промежутке от [0,1], где 0 это timeInterval.</param>
		public Transform GetTransform(float alpha)
		{
			if (alpha < 0 || alpha > 1)
				throw new ArgumentException($"{nameof(alpha)} is less than zero or greater than 1");

			var difAlpha = 1.0f - alpha;
			float angle = difAlpha * AngleZero + alpha * Angle;
			var transform = new Transform(difAlpha * MassCenterZero + alpha * MassCenter, QuaternionMethods.FromAngle2D(angle));

			return new Transform(transform.Position - transform.TransformDirection(LocalCenter), transform.Rotation);
		}

		/// <summary>
		/// Сдвиг движения вперед, получив новое начальное состояние
		/// </summary>
		/// <param name="time">Новое время</param>
		public void Advance(float time)
		{
			var difTimeInterval = 1.0f - TimeInterval;
			if (TimeInterval >= time || difTimeInterval <= _Consts.FLT_EPSILON)
				return;

			float alpha = (time - TimeInterval) / difTimeInterval;
			var difAplha = 1.0f - alpha;
			MassCenterZero = difAplha * MassCenterZero + alpha * MassCenter;
			AngleZero = difAplha * AngleZero + alpha * Angle;
			TimeInterval = time;
		}
	}
}
