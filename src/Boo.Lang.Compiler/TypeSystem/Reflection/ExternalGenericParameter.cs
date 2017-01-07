#region license
// Copyright (c) 2003, 2004, 2005 Rodrigo B. de Oliveira (rbo@acm.org)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Rodrigo B. de Oliveira nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using System;
using System.Reflection;
using Boo.Lang.Compiler.TypeSystem.Reflection;

namespace Boo.Lang.Compiler.TypeSystem
{
	public class ExternalGenericParameter : ExternalType, IGenericParameter
	{
		IMethod _declaringMethod = null;
		
		public ExternalGenericParameter(IReflectionTypeSystemProvider provider, Type type) : base(provider, type)
		{
#if DNXCORE50
            if (type.GetTypeInfo().DeclaringMethod != null)
			{
				_declaringMethod = (IMethod)provider.Map(type.GetTypeInfo().DeclaringMethod);
			}
#else
            if (type.DeclaringMethod != null)
			{
				_declaringMethod = (IMethod)provider.Map(type.DeclaringMethod);
			}
#endif
        }

        public int GenericParameterPosition
		{
			get { return ActualType.GenericParameterPosition; }
		}
		
		public override string FullName 
		{
			get { return string.Format("{0}.{1}", DeclaringEntity.FullName, Name); }
		}
		
		public override IEntity DeclaringEntity
		{
			get 
			{
				//NB: do not use ?? op to workaround csc bug generating invalid IL
				return (null != _declaringMethod) ? (IEntity) _declaringMethod : (IEntity) DeclaringType;
			}
		}

		public Variance Variance
		{
			get
			{
#if DNXCORE50
                GenericParameterAttributes variance = ActualType.GetTypeInfo().GenericParameterAttributes & GenericParameterAttributes.VarianceMask;
#else
                GenericParameterAttributes variance = ActualType.GenericParameterAttributes & GenericParameterAttributes.VarianceMask;
#endif
                switch (variance)
				{
					case GenericParameterAttributes.None:
						return Variance.Invariant;

					case GenericParameterAttributes.Covariant:
						return Variance.Covariant;

					case GenericParameterAttributes.Contravariant:
						return Variance.Contravariant;

					default:
						return Variance.Invariant;
				}
			}
		}

		public IType[] GetTypeConstraints()
		{
			return Util.ArrayUtil.ConvertAll<Type, IType>(
#if DNXCORE50
                ActualType.GetTypeInfo().GetGenericParameterConstraints(),
#else
                ActualType.GetGenericParameterConstraints(), 
#endif
                _provider.Map);
		}

		public bool MustHaveDefaultConstructor
		{
			get
			{
#if DNXCORE50
                return (ActualType.GetTypeInfo().GenericParameterAttributes & GenericParameterAttributes.DefaultConstructorConstraint) == GenericParameterAttributes.DefaultConstructorConstraint;
#else
                return (ActualType.GenericParameterAttributes & GenericParameterAttributes.DefaultConstructorConstraint) == GenericParameterAttributes.DefaultConstructorConstraint;
#endif
            }
        }

		public override bool IsClass
		{
			get
			{
#if DNXCORE50
                return (ActualType.GetTypeInfo().GenericParameterAttributes & GenericParameterAttributes.ReferenceTypeConstraint) == GenericParameterAttributes.ReferenceTypeConstraint;
#else
                return (ActualType.GenericParameterAttributes & GenericParameterAttributes.ReferenceTypeConstraint) == GenericParameterAttributes.ReferenceTypeConstraint;
#endif
            }
        }

		public override bool IsValueType
		{
			get
			{
#if DNXCORE50
                return (ActualType.GetTypeInfo().GenericParameterAttributes & GenericParameterAttributes.NotNullableValueTypeConstraint) == GenericParameterAttributes.NotNullableValueTypeConstraint;
#else
                return (ActualType.GenericParameterAttributes & GenericParameterAttributes.NotNullableValueTypeConstraint) == GenericParameterAttributes.NotNullableValueTypeConstraint;
#endif
            }
        }

		public override string ToString()
		{
			return Name;
		}
	}

}
