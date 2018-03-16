﻿/*
 * Copyright (c) 2018 ETH Zürich, Educational Development and Technology (LET)
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using SafeExamBrowser.Contracts.UserInterface;

namespace SafeExamBrowser.Contracts.Behaviour.OperationModel
{
	/// <summary>
	/// A sequence of <see cref="IOperation"/>s which can be used for sequential procedures, e.g. the initialization &amp; finalization of
	/// an application component. Each operation will be executed failsafe, i.e. the return value will indicate whether a procedure
	/// completed successfully or not.
	/// 
	/// Exemplary execution order for a sequence initialized with operations A, B, C, D:
	/// 
	/// <see cref="TryPerform"/>: A -> B -> C -> D.
	/// <see cref="TryRepeat"/>: A -> B -> C -> D.
	/// <see cref="TryRevert"/>: D -> C -> B -> A.
	/// </summary>
	public interface IOperationSequence
	{
		/// <summary>
		/// The progress indicator to be used when executing an operation. Will be ignored if <c>null</c>.
		/// </summary>
		IProgressIndicator ProgressIndicator { set; }

		/// <summary>
		/// Tries to perform the operations of this sequence according to their initialized order. If any operation fails, the already
		/// performed operations will be reverted.
		/// </summary>
		OperationResult TryPerform();

		/// <summary>
		/// Tries to repeat the operations of this sequence according to their initialized order. If any operation fails, the already
		/// performed operations will not be reverted.
		/// </summary>
		OperationResult TryRepeat();

		/// <summary>
		/// Tries to revert the operations of this sequence. Returns <c>true</c> if all operations were reverted without errors,
		/// otherwise <c>false</c>. The reversion of all operations will continue, even if one or multiple operations fail.
		/// </summary>
		bool TryRevert();
	}
}