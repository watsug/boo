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
	public abstract class RaiseStatementImpl : Statement
	{

		protected Expression _exception;

		protected RaiseStatementImpl()
		{
			InitializeFields();
		}
		
		protected RaiseStatementImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		protected RaiseStatementImpl(Expression exception)
		{
			InitializeFields();
			Exception = exception;
		}
			
		protected RaiseStatementImpl(LexicalInfo lexicalInfo, Expression exception) : base(lexicalInfo)
		{
			InitializeFields();
			Exception = exception;
		}
			
		new public Boo.Lang.Ast.RaiseStatement CloneNode()
		{
			return (Boo.Lang.Ast.RaiseStatement)Clone();
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.RaiseStatement;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			Boo.Lang.Ast.RaiseStatement thisNode = (Boo.Lang.Ast.RaiseStatement)this;
			Boo.Lang.Ast.Statement resultingTypedNode = thisNode;
			transformer.OnRaiseStatement(thisNode, ref resultingTypedNode);
			resultingNode = resultingTypedNode;
		}

		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}

			if (_modifier == existing)
			{
				this.Modifier = (Boo.Lang.Ast.StatementModifier)newNode;
				return true;
			}

			if (_exception == existing)
			{
				this.Exception = (Boo.Lang.Ast.Expression)newNode;
				return true;
			}

			return false;
		}

		override public object Clone()
		{
			Boo.Lang.Ast.RaiseStatement clone = (Boo.Lang.Ast.RaiseStatement)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Boo.Lang.Ast.RaiseStatement));
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = (System.Collections.Hashtable)_properties.Clone();
			

			if (null != _modifier)
			{
				clone._modifier = (StatementModifier)_modifier.Clone();
			}

			if (null != _exception)
			{
				clone._exception = (Expression)_exception.Clone();
			}
			
			return clone;
		}
			
		public Expression Exception
		{
			get
			{
				return _exception;
			}
			

			set
			{
				if (_exception != value)
				{
					_exception = value;
					if (null != _exception)
					{
						_exception.InitializeParent(this);

					}
				}
			}
			

		}
		

		private void InitializeFields()
		{

		}
	}
}
