﻿#region license
// boo - an extensible programming language for the CLI
// Copyright (C) 2004 Rodrigo B. de Oliveira
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// As a special exception, if you link this library with other files to
// produce an executable, this library does not by itself cause the
// resulting executable to be covered by the GNU General Public License.
// This exception does not however invalidate any other reasons why the
// executable file might be covered by the GNU General Public License.
//
// Contact Information
//
// mailto:rbo@acm.org
#endregion

//
// DO NOT EDIT THIS FILE!
//
// This file was generated automatically by
// astgenerator.boo on 2/25/2004 1:16:55 PM
//

namespace Boo.Lang.Ast.Impl
{
	using System;
	using Boo.Lang.Ast;
	
	[Serializable]
	public abstract class TupleTypeReferenceImpl : TypeReference
	{

		protected TypeReference _elementType;

		protected TupleTypeReferenceImpl()
		{
			InitializeFields();
		}
		
		protected TupleTypeReferenceImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		protected TupleTypeReferenceImpl(TypeReference elementType)
		{
			InitializeFields();
			ElementType = elementType;
		}
			
		protected TupleTypeReferenceImpl(LexicalInfo lexicalInfo, TypeReference elementType) : base(lexicalInfo)
		{
			InitializeFields();
			ElementType = elementType;
		}
			
		new public Boo.Lang.Ast.TupleTypeReference CloneNode()
		{
			return (Boo.Lang.Ast.TupleTypeReference)Clone();
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.TupleTypeReference;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			Boo.Lang.Ast.TupleTypeReference thisNode = (Boo.Lang.Ast.TupleTypeReference)this;
			Boo.Lang.Ast.TypeReference resultingTypedNode = thisNode;
			transformer.OnTupleTypeReference(thisNode, ref resultingTypedNode);
			resultingNode = resultingTypedNode;
		}

		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}

			if (_elementType == existing)
			{
				this.ElementType = (Boo.Lang.Ast.TypeReference)newNode;
				return true;
			}

			return false;
		}

		override public object Clone()
		{
			Boo.Lang.Ast.TupleTypeReference clone = (Boo.Lang.Ast.TupleTypeReference)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Boo.Lang.Ast.TupleTypeReference));
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = (System.Collections.Hashtable)_properties.Clone();
			

			if (null != _elementType)
			{
				clone._elementType = (TypeReference)_elementType.Clone();
			}
			
			return clone;
		}
			
		public TypeReference ElementType
		{
			get
			{
				return _elementType;
			}
			

			set
			{
				if (_elementType != value)
				{
					_elementType = value;
					if (null != _elementType)
					{
						_elementType.InitializeParent(this);

					}
				}
			}
			

		}
		

		private void InitializeFields()
		{

		}
	}
}
