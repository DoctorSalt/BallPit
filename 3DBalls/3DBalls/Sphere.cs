﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DBalls
{
	class Sphere : ICloneable
	{
		#region Declarations
		private Model model;
		private Texture2D texture;
		private Effect effect;

		public Vector3 Position
		{
			public get;
			public set
			{
				Position = value;
				boundingShape.Center = value;
			}
		}
		private Vector3 velocity;
		public static Vector3 Acceleration = new Vector3(0, 0, -.5f);
		public BoundingSphere boundingShape;
		#endregion

		#region Constructors
		public Sphere(
			Model model, Texture2D texture, 
			Vector3 position, float radius, Effect effect)
		{
			this.model = model;
			this.texture = texture;

			this.Position = position;
			this.boundingShape = new BoundingSphere(position, radius);
			this.effect = effect;
		}

		#endregion

		#region Public Methods
		public void Update(GameTime gameTime)
		{
			Position += velocity;
			velocity += Acceleration;		
		}

		public void Draw()
		{
			DrawHelper.DrawModelWithEffect(model, texture, Matrix.CreateTranslation(Position), effect);
		}

		#endregion

		#region Cloning Methods
		/// <summary>
		/// Used to clone otherSphere, in case Clone doesn't work
		/// </summary>
		/// <param name="otherSphere"></param>
		public Sphere(Sphere otherSphere)
		{
			this.model = otherSphere.model;
			this.texture = otherSphere.texture;
			this.effect = otherSphere.effect.Clone();
			this.Position = otherSphere.Position;
			this.velocity = otherSphere.velocity;
			this.boundingShape = otherSphere.boundingShape;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}
		public Sphere Clone()
		{
			return (Sphere)this.MemberwiseClone();
		}
		#endregion
	}
}
